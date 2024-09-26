using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.WebApp.Extensions;
using LocadoraDeVeiculos.WebApp.Controllers.Shared;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LocadoraDeVeiculos.WebApp.Controllers;
public class CondutorController : WebController
{
    readonly IMapper _mapeador;
    readonly ClienteService _serviceCliente;
    readonly CondutorService _serviceCondutor;

    public CondutorController(IMapper mapeador, ClienteService serviceCliente, CondutorService condutorService, AuthService authService) : base(authService)
    {
        _mapeador = mapeador;
        _serviceCliente = serviceCliente;
        _serviceCondutor = condutorService;
    }

    public IActionResult Listar()
    {
        var resultado = _serviceCondutor.SelecionarTodos(EmpresaId.GetValueOrDefault());

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction("Index", "Home");
        }

        var condutores = resultado.Value;

        var listarVM = _mapeador.Map<IEnumerable<ListarCondutorViewModel>>(condutores);

        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

        return View(listarVM);
    }

    public IActionResult Detalhes(int id)
    {
        var resultado = _serviceCondutor.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var condutor = resultado.Value;

        var detalhesVM = _mapeador.Map<FormCondutorViewModel>(condutor);

        return View(detalhesVM);
    }

    public IActionResult Cadastrar()
    {
        return View(CarregarDadosFormulario());
    }

    [HttpPost]
    public IActionResult Cadastrar(FormCondutorViewModel cadastroVm)
    {
        ModelState.Remove("Cliente");
        ModelState.Remove("Clientes");

        if (!ModelState.IsValid)
            return View(CarregarDadosFormulario(cadastroVm));

        var condutor = _mapeador.Map<Condutor>(cadastroVm);

        var resultado = _serviceCondutor.Cadastrar(condutor);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{condutor.Id}] foi cadastrado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public JsonResult CarregarDadosCondutores(int clienteId)
    {
        var resultado = _serviceCliente.SelecionarId(clienteId);

        if (resultado.IsFailed)
        {
            return Json(new { success = false, message = "Cliente não encontrado." });
        }

        var cliente = resultado.Value;

        var dadosCliente = new
        {
            Nome = cliente.Nome,
            CPF = cliente.CPF,
            Telefone = cliente.Telefone,
            Email = cliente.Email
        };

        return Json(new { success = true, dados = dadosCliente });
    }


    public IActionResult Editar(int id)
    {
        var resultado = _serviceCondutor.SelecionarId(id);
        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var clientes = _serviceCliente.SelecionarTodos(EmpresaId.GetValueOrDefault());

        if (clientes.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return null;
        }

        var condutor = resultado.Value;

        var editarVm = _mapeador.Map<FormCondutorViewModel>(condutor);

        var clientesElegiveis = clientes.Value;

        editarVm.Clientes = clientesElegiveis
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nome,
                Selected = c.Id == condutor.Id
            });

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(FormCondutorViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        var condutor = _mapeador.Map<Condutor>(editarVm);

        var resultado = _serviceCondutor.Editar(condutor);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Editar));
        }

        ApresentarMensagemSucesso($"O registro ID [{condutor.Id}] foi editado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var resultado = _serviceCondutor.SelecionarId(id);
        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());
            return RedirectToAction(nameof(Listar));
        }

        var condutor = resultado.Value;

        var excluirVm = _mapeador.Map<FormCondutorViewModel>(condutor);

        return View(excluirVm);
    }

    [HttpPost]
    public IActionResult Excluir(FormCondutorViewModel excluirVm)
    {
        var resultado = _serviceCondutor.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }


        ApresentarMensagemSucesso($"O registro foi deletado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    private FormCondutorViewModel? CarregarDadosFormulario(
      FormCondutorViewModel? dadosPrevios = null)
    {
        var resultadoClientes = _serviceCliente.SelecionarTodos(EmpresaId.GetValueOrDefault());

        if (resultadoClientes.IsFailed)
        {
            ApresentarMensagemFalha(resultadoClientes.ToResult());
            return null;
        }

        var Disponiveis = resultadoClientes.Value;

        if (dadosPrevios is null)
        {
            var formularioVm = new FormCondutorViewModel
            {
                Clientes = Disponiveis.Select(c => new SelectListItem(c.Nome, c.Id.ToString()))
            };
            return formularioVm;
        }

        dadosPrevios.Clientes = Disponiveis.Select(c => new SelectListItem(c.Nome, c.Id.ToString()));
        return dadosPrevios;
    }
}
