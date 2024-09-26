using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.Dominio.ModuloPessoas;
using LocadoraDeVeiculos.WebApp.Controllers.Shared;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Controllers;

[Authorize(Roles = "Empresa")]
public class FuncionarioController : WebController
{
    private readonly FuncionarioService _funcionarioService;
    private readonly IMapper _mapeador;

    public FuncionarioController(
        FuncionarioService funcionarioService,
        AuthService authService,
        IMapper mapeador
    ) : base(authService)
    {
        _funcionarioService = funcionarioService;
        _mapeador = mapeador;
    }

    public async Task<IActionResult> Listar()
    {
        var resultado = _funcionarioService.SelecionarFuncionariosDaEmpresa(EmpresaId.GetValueOrDefault());

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction("Index", "Home");
        }

        var funcionarios = resultado.Value;

        var listarFuncionariosVm = _mapeador.Map<IEnumerable<ListarFuncionarioViewModel>>(funcionarios);

        return View(listarFuncionariosVm);
    }

    public IActionResult Cadastrar()
    {
        return View(new FormFuncionarioViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(FormFuncionarioViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        var funcionario = _mapeador.Map<Funcionario>(cadastrarVm);

        var resultadoFuncionario = await _funcionarioService.Cadastrar(
            funcionario,
            cadastrarVm.LoginUsuario,
            cadastrarVm.Senha
        );

        if (resultadoFuncionario.IsFailed)
        {
            ApresentarMensagemFalha(resultadoFuncionario.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O funcionário ID [{funcionario.Id}] foi inserido com sucesso!");

        return RedirectToAction(nameof(Listar));
    }
}