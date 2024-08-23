using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;

namespace LocadoraDeVeiculos.WebApp.Controllers;
public class PlanoController : WebController
{
    readonly IMapper _mapeador;
    readonly PlanoService _servicePlano;
    readonly GrupoVeiculosService _serviceGrupo;

    public PlanoController(IMapper mapeador, PlanoService servicePlano, GrupoVeiculosService serviceGrupo)
    {
        _mapeador = mapeador;
        _servicePlano = servicePlano;
        _serviceGrupo = serviceGrupo;
    }

    public IActionResult Listar()
    {
        var resultado = _servicePlano.SelecionarTodos();

        if(resultado.IsFailed)
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
        return View();
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

        if(resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{plano.Id}] foi cadastrado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Editar(int id, EditarPlanoViewModel editarVm)
    {

        return View();
    }

    public IActionResult Excluir(int id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Excluir(int id, ExcluirPlanoViewModel excluirVm)
    {
        return View();
    }
    private FormPlanoViewModels? CarregarDadosFormulario(
       FormPlanoViewModels? dadosPrevios = null)
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
