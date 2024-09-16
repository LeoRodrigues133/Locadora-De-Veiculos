using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.WebApp.Controllers.Shared;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;

namespace LocadoraDeVeiculos.WebApp.Controllers;
[Authorize(Roles = "Empresa,Funcionario")]
public class CombustivelController : WebController
{
    private readonly CombustivelService servicoCombustivel;
    private readonly IMapper mapeador;

    public CombustivelController(
        AuthService _servicoAuth,
        CombustivelService servicoCombustivel,
        IMapper mapeador
    ) : base(_servicoAuth)
    {
        this.servicoCombustivel = servicoCombustivel;
        this.mapeador = mapeador;
    }

    public IActionResult Configuracao()
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
    public IActionResult Configuracao(FormCombustivelViewModel formularioVm)
    {
        var config = mapeador.Map<Combustivel>(formularioVm);

        var resultado = servicoCombustivel.SalvarConfiguracao(config);

        if (resultado.IsFailed)
            return RedirectToAction("Index", "Home");

        ApresentarMensagemSucesso("A configuração foi salva com sucesso!");

        return RedirectToAction("Index", "Home");
    }
}