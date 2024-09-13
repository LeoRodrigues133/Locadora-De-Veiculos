using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocadoraDeVeiculos.WebApp.Extensions;
using LocadoraDeVeiculos.Aplicacao.Services;
using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.WebApp.Controllers.Shared;

namespace LocadoraDeVeiculos.WebApp.Controllers;
public class PlanoController : WebController
{
    readonly IMapper _mapeador;
    readonly PlanoService _servicePlano;
    readonly GrupoVeiculosService _serviceGrupo;

    public PlanoController(IMapper mapeador, PlanoService servicePlano, GrupoVeiculosService serviceGrupo, AuthService authService) : base(authService)
    {
        _mapeador = mapeador;
        _servicePlano = servicePlano;
        _serviceGrupo = serviceGrupo;
    }

    public IActionResult Listar()
    {
        var resultado = _servicePlano.SelecionarTodos(EmpresaId.GetValueOrDefault());

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return View("Index", "Home");
        }

        var planos = resultado.Value;

        var listarVm = _mapeador.Map<IEnumerable<ListarPlanoViewModel>>(planos);

        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

        return View(listarVm);
    }

    public IActionResult Detalhes(int id)
    {
        var resultado = _servicePlano.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        var plano = resultado.Value;

        var detalhesVm = _mapeador.Map<DetalhesPlanoViewModel>(plano);

        return View(detalhesVm);
    }

    public IActionResult Cadastrar()
    {
        return View(CarregarDadosFormulario());
    }

    [HttpPost]
    public IActionResult Cadastrar(CadastroPlanoViewModel cadastroVm)
    {
        if (!ModelState.IsValid)
            return View(CarregarDadosFormulario(cadastroVm));

        var plano = _mapeador.Map<Plano>(cadastroVm);

        var resultado = _servicePlano.Cadastrar(plano);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{plano.Id}] foi cadastrado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var resultado = _servicePlano.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        var resultadoGrupos = _serviceGrupo.SelecionarTodos(EmpresaId.GetValueOrDefault());

        if (resultadoGrupos.IsFailed)
        {
            ApresentarMensagemFalha(resultadoGrupos.ToResult());

            return null;
        }

        var plano = resultado.Value;

        var editarVm = _mapeador.Map<EditarPlanoViewModel>(plano);

        var gruposDisponiveis = resultadoGrupos.Value;

        editarVm.GrupoVeiculos = gruposDisponiveis
            .Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Nome,
                Selected = g.Id == plano.GrupoVeiculos.Id // Seleciona o grupo associado ao veículo
            }).ToList();

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(int id, EditarPlanoViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        var plano = _mapeador.Map<Plano>(editarVm);

        var resultado = _servicePlano.Editar(plano);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Editar));
        }

        ApresentarMensagemSucesso($"O registro ID [{plano.Id}] foi editado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var resultado = _servicePlano.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        var plano = resultado.Value;

        var excluirVm = _mapeador.Map<DetalhesPlanoViewModel>(plano);

        return View(excluirVm);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesPlanoViewModel excluirVm)
    {
        var resultado = _servicePlano.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro foi deletado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }
    private FormPlanoViewModels? CarregarDadosFormulario(
       FormPlanoViewModels? dadosPrevios = null)
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
            var formularioVm = new FormPlanoViewModels
            {
                GrupoVeiculos = gruposDisponiveis.Select(g => new SelectListItem(g.Nome, g.Id.ToString()))
            };
            return formularioVm;
        }

        dadosPrevios.GrupoVeiculos = gruposDisponiveis.Select(g => new SelectListItem(g.Nome, g.Id.ToString()));
        return dadosPrevios;
    }
}
