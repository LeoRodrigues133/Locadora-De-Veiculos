using FluentResults;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeVeiculos.WebApp.Extensions;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraDeVeiculos.Aplicacao.Services;

namespace LocadoraDeVeiculos.WebApp.Controllers.Shared;

public class WebController : Controller
{

    protected readonly AuthService _authService;

    protected int? EmpresaId
    {
        get
        {
            var empresaId = _authService.ObterIdEmpresaAsync(User).Result;

            return empresaId;
        }
    }
    protected WebController(AuthService authService)
    {
        _authService = authService;
    }

    protected IActionResult MensagemRegistroNaoEncontrado(int idRegistro)
    {
        TempData.SerializarMensagemViewModel(new MensagemViewModel
        {
            Titulo = "Erro",
            Mensagem = $"Não foi possível encontrar o registro ID [{idRegistro}]!"
        });

        return RedirectToAction("Index", "Inicio");
    }

    protected void ApresentarMensagemFalha(Result resultado)
    {
        ViewBag.Mensagem = new MensagemViewModel
        {
            Titulo = "Falha",
            Mensagem = resultado.Errors[0].Message
        };
    }

    protected void ApresentarMensagemSucesso(string mensagem)
    {
        TempData.SerializarMensagemViewModel(new MensagemViewModel
        {
            Titulo = "Sucesso",
            Mensagem = mensagem
        });
    }
    protected void ApresentarMensagemFalhaEditavel(string mensagem)
    {
        TempData.SerializarMensagemViewModel(new MensagemViewModel
        {
            Titulo = "Falha",
            Mensagem = mensagem
        });
    }
}
