using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;
using LocadoraDeVeiculos.WebApp.Controllers.Shared;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeVeiculos.WebApp.Controllers;
[Authorize(Roles = "Empresa,Funcionario")]
public class CombustivelController : WebController
{
    private readonly ServicoCombustivel servicoCombustivel;
    private readonly IMapper mapeador;

    public CombustivelController(
        AuthService _servicoAuth,
        ServicoCombustivel servicoCombustivel,
        IMapper mapeador
    ) : base(_servicoAuth)
    {
        this.servicoCombustivel = servicoCombustivel;
        this.mapeador = mapeador;
    }

    public IActionResult Configurar()
    {
        var resultado = servicoCombustivel
            .ObterConfiguracao(EmpresaId.GetValueOrDefault());

        if (resultado.IsFailed)
            return RedirectToAction("Index", "Home");

        var configuracaoCombustivel = resultado.Value;

        var formularioVm = mapeador.Map<FormCombustivelViewModel>(configuracaoCombustivel);

        return View(formularioVm);
    }

    [HttpPost]
    public IActionResult Configurar(FormCombustivelViewModel formularioVm)
    {
        var config = mapeador.Map<Combustivel>(formularioVm);

        var resultado = servicoCombustivel.SalvarConfiguracao(config);

        if (resultado.IsFailed)
            return RedirectToAction("Index", "Home");

        ApresentarMensagemSucesso("A configuração foi salva com sucesso!");

        return RedirectToAction("Index", "Home");
    }
}