using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraDeVeiculos.WebApp.Extensions;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.WebApp.Controllers;
public class GrupoVeiculosController : WebController
{
    readonly IMapper _mapeador;
    readonly GrupoVeiculosService _serviceGrupo;

    public GrupoVeiculosController(IMapper mapeador, GrupoVeiculosService grupoService)
    {
        _mapeador = mapeador;
        _serviceGrupo = grupoService;
    }
    public IActionResult Listar()
    {
        var resultado = _serviceGrupo.SelecionarTodos();

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return View("Index", "Home");
        }

        var grupoVeiculos = resultado.Value;

        var listarVM = _mapeador.Map<IEnumerable<ListarGrupoViewModel>>(grupoVeiculos);

        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

        return View(listarVM);
    }

    public ActionResult Detalhes(int id)
    {
        return View();
    }

    public ActionResult Cadastrar()
    {
        var CadastroVm = new GrupoViewModels();

        return View(CadastroVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(GrupoViewModels CadastroVm)
    {
        if (!ModelState.IsValid)
            return View(CadastroVm);

        var grupo = _mapeador.Map<GrupoVeiculos>(CadastroVm);

        var resultado = _serviceGrupo.Cadastrar(grupo);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{grupo.Id}] foi cadastrado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public ActionResult Editar(int id)
    {
        return View();
    }

    [HttpPost]
    public ActionResult Editar(int id, EditarGrupoViewModel EditarVm)
    {

        return View();
    }

    public ActionResult Excluir(int id)
    {
        return View();
    }

    [HttpPost]
    public ActionResult Excluir(int id, ExcluirGrupoViewModel ExcluirVm)
    {

        return View();
    }
}
