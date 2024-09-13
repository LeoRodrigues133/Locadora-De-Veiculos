using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraDeVeiculos.WebApp.Extensions;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.WebApp.Controllers.Shared;

namespace LocadoraDeVeiculos.WebApp.Controllers;
public class GrupoVeiculosController : WebController
{
    readonly IMapper _mapeador;
    readonly GrupoVeiculosService _serviceGrupo;

    public GrupoVeiculosController(IMapper mapeador, GrupoVeiculosService grupoService, AuthService authService) : base(authService)
    {
        _mapeador = mapeador;
        _serviceGrupo = grupoService;
    }
    public IActionResult Listar()
    {
        var resultado = _serviceGrupo.SelecionarTodos(EmpresaId.GetValueOrDefault());

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
        var resultado = _serviceGrupo.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var grupo = resultado.Value;

        var detalheVm = _mapeador.Map<DetalhesGrupoViewModel>(grupo);

        return View(detalheVm);
    }

    public ActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastroGrupoViewModel CadastroVm)
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
        var resultado = _serviceGrupo.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var grupo = resultado.Value;

        var editarVm = _mapeador.Map<EditarGrupoViewModel>(grupo);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarGrupoViewModel editarVm)
    {
        var grupo = _mapeador.Map<GrupoVeiculos>(editarVm);

        var resultado = _serviceGrupo.Editar(grupo);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{grupo.Id}] foi editado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public ActionResult Excluir(int id)
    {
        var resultado = _serviceGrupo.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var grupo = resultado.Value;

        var excluirVm = _mapeador.Map<ExcluirGrupoViewModel>(grupo);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirGrupoViewModel excluirVm)
    {
        var resultado = _serviceGrupo.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro foi deletado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }
}
