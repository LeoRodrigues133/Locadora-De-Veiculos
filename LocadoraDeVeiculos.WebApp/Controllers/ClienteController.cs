using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraDeVeiculos.WebApp.Extensions;
using LocadoraDeVeiculos.Aplicacao.Services;
using FluentResults;

namespace LocadoraDeVeiculos.WebApp.Controllers;
public class ClienteController : WebController
{
    readonly IMapper _mapeador;
    readonly ClienteService _serviceCliente;

    public ClienteController(IMapper mapeador, ClienteService serviceCliente)
    {
        _mapeador = mapeador;
        _serviceCliente = serviceCliente;
    }

    public IActionResult Listar()
    {
        var resultado = _serviceCliente.SelecionarTodos();

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return View("Index", "Home");
        }

        var clientes = resultado.Value;

        var listarVm = _mapeador.Map<IEnumerable<ListarClienteViewModel>>(clientes);

        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

        return View(listarVm);
    }

    public ActionResult Detalhes(int id)
    {
        var resultado = _serviceCliente.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        var cliente = resultado.Value;

        var detalhesVm = _mapeador.Map<DetalhesClienteViewModel>(cliente);

        return View(detalhesVm);
    }

    public ActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastroClienteViewModel cadastroVm)
    {
        if (!ModelState.IsValid)
            return View(cadastroVm);

        var cliente = _mapeador.Map<Cliente>(cadastroVm);

        var resultado = _serviceCliente.Cadastrar(cliente);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{cliente.Id}] foi cadastrado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public ActionResult Editar(int id)
    {
        var resultado = _serviceCliente.SelecionarId(id);

        if(resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var cliente = resultado.Value;

        var editarVm = _mapeador.Map<EditarClienteViewModel>(cliente);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarClienteViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        var cliente = _mapeador.Map<Cliente>(editarVm);

        var resultado = _serviceCliente.Editar(cliente);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Editar));
        }

        ApresentarMensagemSucesso($"O registro ID [{cliente.Id}] foi editado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public ActionResult Excluir(int id)
    {
        var resultado = _serviceCliente.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        var cliente = resultado.Value;

        var detalhesVm = _mapeador.Map<ExcluirClienteViewModel>(cliente);

        return View(detalhesVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirClienteViewModel excluirVm)
    {
        var resultado = _serviceCliente.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro foi deletado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }
}
