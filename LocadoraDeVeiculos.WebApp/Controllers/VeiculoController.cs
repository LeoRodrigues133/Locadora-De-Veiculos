using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocadoraDeVeiculos.WebApp.Extensions;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.WebApp.Controllers.Shared;

namespace LocadoraDeVeiculos.WebApp.Controllers;

public class VeiculoController : WebController
{
    readonly IMapper _mapeador;
    readonly VeiculoService _serviceVeiculo;
    readonly GrupoVeiculosService _serviceGrupo;

    public VeiculoController(VeiculoService serviceVeiculo, GrupoVeiculosService serviceGrupo, IMapper mapeador,
        AuthService authService) : base(authService)
    {
        _mapeador = mapeador;
        _serviceGrupo = serviceGrupo;
        _serviceVeiculo = serviceVeiculo;
    }

    public IActionResult Listar()
    {
        var resultado = _serviceVeiculo.SelecionarTodos(EmpresaId.GetValueOrDefault());

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return View("Index", "Home");
        }

        var veiculos = resultado.Value;
        
        var listarVM = _mapeador.Map<IEnumerable<ListarVeiculoViewModel>>(veiculos);

        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

        return View(listarVM);
    }

    public IActionResult Detalhes(int id)
    {
        var resultado = _serviceVeiculo.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return View("Index", "Home");
        }

        var veiculo = resultado.Value;

        var detalhesVm = _mapeador.Map<FormVeiculoViewModel>(veiculo);

        return View(detalhesVm);
    }

    public IActionResult Cadastrar()
    {
        return View(CarregarDadosFormulario());
    }

    [HttpPost]
    public IActionResult Cadastrar(FormVeiculoViewModel cadastroVm)
    {
        if (!ModelState.IsValid)
            return View(CarregarDadosFormulario(cadastroVm));

        var veiculo = _mapeador.Map<Veiculo>(cadastroVm);

        var resultado = _serviceVeiculo.Cadastrar(veiculo);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{veiculo.Id}] foi cadastrado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var resultado = _serviceVeiculo.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); 

            return RedirectToAction(nameof(Listar));
        }

        var resultadoGrupos = _serviceGrupo.SelecionarTodos(EmpresaId.GetValueOrDefault());

        if (resultadoGrupos.IsFailed)
        {
            ApresentarMensagemFalha(resultadoGrupos.ToResult());

            return null;
        }

        var veiculo = resultado.Value;

        var editarVm = _mapeador.Map<FormVeiculoViewModel>(veiculo);

        var gruposDisponiveis = resultadoGrupos.Value;

        editarVm.GrupoVeiculos = gruposDisponiveis
            .Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Nome,
                Selected = g.Id == veiculo.GrupoVeiculos.Id
            }).ToList();

        if (veiculo.Alugado == true)
        {
            ApresentarMensagemFalhaEditavel("O veículo não pode ser editado enquanto estiver alugado.");

            return RedirectToAction(nameof(Listar));
        }

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(FormVeiculoViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        var veiculo = _mapeador.Map<Veiculo>(editarVm);

        var resultado = _serviceVeiculo.Editar(veiculo);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); 

            return RedirectToAction(nameof(Editar));
        }

        ApresentarMensagemSucesso($"O registro ID [{veiculo.Id}] foi editado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var resultado = _serviceVeiculo.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var veiculo = resultado.Value;

        var detalhesVm = _mapeador.Map<FormVeiculoViewModel>(veiculo);

        return View(detalhesVm);
    }

    [HttpPost]
    public IActionResult Excluir(FormVeiculoViewModel detalhesVm)
    {
        var resultado = _serviceVeiculo.Excluir(detalhesVm.Id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); 

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro foi deletado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }
    private FormVeiculoViewModel? CarregarDadosFormulario(
       FormVeiculoViewModel? dadosPrevios = null)
    {
        var resultadoGrupos = _serviceGrupo.SelecionarTodos(EmpresaId.GetValueOrDefault());

        if (resultadoGrupos.IsFailed)
        {
            ApresentarMensagemFalha(resultadoGrupos.ToResult());
            return null;
        }

        var gruposDisponiveis = resultadoGrupos.Value;

        if (dadosPrevios is null)
        {
            var formularioVm = new FormVeiculoViewModel
            {
                GrupoVeiculos = gruposDisponiveis.Select(g => new SelectListItem(g.Nome, g.Id.ToString()))
            };
            return formularioVm;
        }

        dadosPrevios.GrupoVeiculos = gruposDisponiveis.Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

        return dadosPrevios;
    }
}
