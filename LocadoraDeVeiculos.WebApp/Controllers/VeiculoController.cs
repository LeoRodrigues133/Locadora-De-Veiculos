using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.WebApp.Extensions;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeVeiculos.WebApp.Controllers;

public class VeiculoController : WebController
{
    readonly IMapper _mapeador;
    readonly VeiculoService _serviceVeiculo;

    public VeiculoController(VeiculoService serviceVeiculo, IMapper mapeador)
    {
        _mapeador = mapeador;
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

        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel(); ////Ainda não implementado

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
        var cadastroVm = new CadastroVeiculoViewModel();
        return View(cadastroVm);
    }

    [HttpPost]
    public IActionResult Cadastrar(CadastroVeiculoViewModel cadastroVm)
    {
        if (!ModelState.IsValid)
            return View(cadastroVm);

        var veiculo = _mapeador.Map<Veiculo>(cadastroVm);

        var resultado = _serviceVeiculo.Cadastrar(veiculo);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{veiculo.Id}] foi cadastrado com sucesso!"); ////Ainda não implementado


        return RedirectToAction(nameof(Listar));

    }

    public ActionResult Editar(int id)
    {
        var resultado = _serviceVeiculo.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        var veiculo = resultado.Value;

        var editarVM = _mapeador.Map<EditarVeiculoViewModel>(veiculo);

        return View(editarVM);
    }

    [HttpPost]
    public ActionResult Editar(EditarVeiculoViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        var veiculo = _mapeador.Map<Veiculo>(editarVm);

        var resultado = _serviceVeiculo.Editar(veiculo);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{veiculo.Id}] foi editado com sucesso!"); ////Ainda não implementado;

        return RedirectToAction(nameof(Listar));
    }

    public ActionResult Excluir(int id)
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
    public ActionResult Excluir(DetalhesVeiculoViewModel detalhesVm)
    {
        var resultado = _serviceVeiculo.Excluir(detalhesVm.Id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro foi deletado com sucesso!"); ////Ainda não implementado;


        return RedirectToAction(nameof(Listar));
    }
}
