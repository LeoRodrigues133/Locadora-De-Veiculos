using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.Dominio.ModuloAuth;
using LocadoraDeVeiculos.Dominio.ModuloUsuario;
using LocadoraDeVeiculos.WebApp.Controllers.Shared;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeVeiculos.WebApp.Controllers;
public class AuthController : WebController
{
    readonly AuthService _authService;
    public AuthController(AuthService authService) : base(authService)
    {
        _authService = authService;
    }

    public IActionResult Registrar()
    {
        return View(new RegistrarEmpresaViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(RegistrarEmpresaViewModel registrarVm)
    {
        if (!ModelState.IsValid)
            return View(registrarVm);

        var usuario = new Usuario()
        {
            UserName = registrarVm.Usuario,
            Email = registrarVm.Email
        };

        var senha = registrarVm.Senha!;

        var resultado = await _authService
            .Registrar(usuario, senha, TipoUsuarioEnum.Empresa);

        if (resultado.IsSuccess)
            return RedirectToAction("Index", "Home");

        foreach (var erro in resultado.Errors)
            ModelState.AddModelError(string.Empty, erro.Message);

        return View(registrarVm);
    }

    public IActionResult Login(string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginEmpresaViewModel loginVm, string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;

        if (!ModelState.IsValid)
            return View(loginVm);

        var resultado = await _authService.Login(loginVm.Usuario!, loginVm.Senha!);

        if (resultado.IsSuccess)
            return LocalRedirect(returnUrl ?? "/");

        var msgErro = resultado.Errors.First().Message;

        ModelState.AddModelError(string.Empty, msgErro);

        return View(loginVm);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _authService.Logout();

        return RedirectToAction(nameof(Login));
    }

    public IActionResult AcessoNegado()
    {
        return View();
    }
}