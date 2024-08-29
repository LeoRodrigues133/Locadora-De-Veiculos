using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.WebApp.Extensions;

namespace LocadoraDeVeiculos.WebApp.Controllers;
public class AluguelController : WebController
{
    readonly IMapper _mapeador;
    readonly PlanoService _planoService;
    readonly TaxasService _taxasService;
    readonly VeiculoService _veiculoService;
    readonly AluguelService _aluguelService;
    readonly CondutorService _condutorService;
    readonly GrupoVeiculosService _grupoVeiculosService;

    public AluguelController(
        IMapper mapeador,
        PlanoService planoService,
        TaxasService taxasService,
        VeiculoService veiculoService,
        AluguelService aluguelService,
        CondutorService condutorService,
        GrupoVeiculosService grupoVeiculosService)
    {
        _mapeador = mapeador;
        _planoService = planoService;
        _taxasService = taxasService;
        _veiculoService = veiculoService;
        _aluguelService = aluguelService;
        _condutorService = condutorService;
        _grupoVeiculosService = grupoVeiculosService;
    }

    public IActionResult Listar()
    {
        var resultado = _aluguelService.SelecionarTodos();

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return View("Index", "Home");
        }
        var alugueis = resultado.Value;

        var listarVM = _mapeador.Map<IEnumerable<ListarAluguelViewModel>>(alugueis);

        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

        return View(listarVM);
    }

    public IActionResult Datalhes(int id)
    {
        return View();
    }

    public IActionResult Cadastrar()
    {
        return View(CarregarDados());
    }

    [HttpPost]
    public IActionResult Cadastrar(CadastroAluguelViewModel cadastroVm)
    {
        if (!ModelState.IsValid)
            return View(CarregarDados(cadastroVm));


        var aluguel = _mapeador.Map<Aluguel>(cadastroVm);

        foreach (var taxaId in cadastroVm.taxasSelecionadas)
        {
            var result = _taxasService.SelecionarId(taxaId);
            var taxa = result.Value;

            if (taxa is not null)
                aluguel.Taxas.Add(taxa);
        }

        var resultado = _aluguelService.Cadastrar(aluguel);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{aluguel.Id}] foi cadastrado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Editar(EditarAluguelViewModel editarVm)
    {
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Excluir(ExcluirAluguelViewModel excluirVm)
    {
        return RedirectToAction(nameof(Listar));
    }

    private FormAluguelViewModel? CarregarDados(FormAluguelViewModel? model = null)
    {
        var resultadoGrupos = _grupoVeiculosService.SelecionarTodos();
        var resultadoVeiculos = _veiculoService.SelecionarTodos();
        var resultadoCondutores = _condutorService.SelecionarTodos();
        var resultadoPlanos = _planoService.SelecionarTodos();
        var resultadoTaxas = _taxasService.SelecionarTodos();

        if (resultadoGrupos.IsFailed)
        {
            ApresentarMensagemFalha(resultadoGrupos.ToResult());
            return null;
        }

        if (resultadoCondutores.IsFailed)
        {
            ApresentarMensagemFalha(resultadoCondutores.ToResult());
            return null;
        }

        if (resultadoPlanos.IsFailed)
        {
            ApresentarMensagemFalha(resultadoPlanos.ToResult());
            return null;
        }
        if (resultadoVeiculos.IsFailed)
        {
            ApresentarMensagemFalha(resultadoVeiculos.ToResult());
            return null;
        }
        if(resultadoTaxas.IsFailed)
        {
            ApresentarMensagemFalha(resultadoTaxas.ToResult());
            return null;
        }
        var taxasD = resultadoTaxas.Value;
        var gruposD = resultadoGrupos.Value;
        var planosD = resultadoPlanos.Value;
        var veiculosD = resultadoVeiculos.Value;
        var condutoresD = resultadoCondutores.Value;

        model ??= new CadastroAluguelViewModel
        {
            Taxas = taxasD,
            Grupos = gruposD.Select(x => new SelectListItem(x.Nome, x.Id.ToString())),
            Veiculos = veiculosD.Select(x => new SelectListItem(x.Modelo, x.Id.ToString())),
            Condutores = condutoresD.Select(x => new SelectListItem(x.Nome, x.Id.ToString())),
            Planos = planosD.Select(x => new SelectListItem(x.TipoPlano.ToString(), x.Id.ToString()))
        };

        return model;
    }


}
