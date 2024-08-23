using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraDeVeiculos.WebApp.Extensions;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.WebApp.Controllers;

public class VeiculoController : WebController
{
    readonly IMapper _mapeador;
    readonly VeiculoService _serviceVeiculo;
    readonly GrupoVeiculosService _serviceGrupo;

    public VeiculoController(VeiculoService serviceVeiculo, GrupoVeiculosService serviceGrupo, IMapper mapeador)
    {
        _mapeador = mapeador;
        _serviceGrupo = serviceGrupo;
        _serviceVeiculo = serviceVeiculo;
    }

    public IActionResult Listar()
    {
        var resultado = _serviceVeiculo.SelecionarTodos();

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

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

        var detalhesVm = _mapeador.Map<DetalhesVeiculoViewModel>(veiculo);

        return View(detalhesVm);
    }

    public IActionResult Cadastrar()
    {

        return View(CarregarDadosFormulario());
    }

    [HttpPost]
    public IActionResult Cadastrar(CadastroVeiculoViewModel cadastroVm)
    {
        if (!ModelState.IsValid)
            return View(CarregarDadosFormulario(cadastroVm));

        var veiculo = _mapeador.Map<Veiculo>(cadastroVm);

        var resultado = _serviceVeiculo.Cadastrar(veiculo);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

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
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        var resultadoGrupos = _serviceGrupo.SelecionarTodos();

        if (resultadoGrupos.IsFailed)
        {
            ApresentarMensagemFalha(resultadoGrupos.ToResult());

            return null;
        }

        var veiculo = resultado.Value;

        var editarVm = _mapeador.Map<EditarVeiculoViewModel>(veiculo);

        var gruposDisponiveis = resultadoGrupos.Value;

        editarVm.GrupoVeiculos = gruposDisponiveis
            .Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Nome,
                Selected = g.Id == veiculo.GrupoVeiculos.Id // Seleciona o grupo associado ao veículo
            }).ToList();

        if (veiculo.Alugado == true)
        {
            ApresentarMensagemFalhaEditavel("O veículo não pode ser editado enquanto estiver alugado.");

            return RedirectToAction(nameof(Listar));
        }

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(EditarVeiculoViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        var veiculo = _mapeador.Map<Veiculo>(editarVm);

        var resultado = _serviceVeiculo.Editar(veiculo);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

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
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        var veiculo = resultado.Value;

        var detalhesVm = _mapeador.Map<DetalhesVeiculoViewModel>(veiculo);

        return View(detalhesVm);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesVeiculoViewModel detalhesVm)
    {
        var resultado = _serviceVeiculo.Excluir(detalhesVm.Id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro foi deletado com sucesso!");


        return RedirectToAction(nameof(Listar));
    }
    private FormVeiculoViewModel? CarregarDadosFormulario(
       FormVeiculoViewModel? dadosPrevios = null)
    {
        var resultadoGrupos = _serviceGrupo.SelecionarTodos();

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
