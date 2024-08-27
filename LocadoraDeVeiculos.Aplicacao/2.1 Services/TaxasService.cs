using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;

namespace LocadoraDeVeiculos.Aplicacao.Services;
public class TaxasService
{
    readonly IRepositorioTaxaEServicos _repositorioTaxa;

    public TaxasService(IRepositorioTaxaEServicos repositorioTaxa)
    {
        _repositorioTaxa = repositorioTaxa;
    }

    public Result<TaxaServico> Cadastrar(TaxaServico taxa)
    {
        _repositorioTaxa.Cadastrar(taxa);

        return Result.Ok(taxa);
    }
    public Result<TaxaServico> Editar(TaxaServico taxaEditada) {

        var taxaSelecionada = _repositorioTaxa.SelecionarPorId(taxaEditada.Id);

        #region edit
        taxaSelecionada.Nome = taxaEditada.Nome;
        taxaSelecionada.Valor = taxaEditada.Valor;
        taxaSelecionada.TipoDeCobranca = taxaEditada.TipoDeCobranca;
        #endregion

        _repositorioTaxa.Editar(taxaSelecionada);

        return Result.Ok(taxaSelecionada);
    }

    public Result<TaxaServico> Excluir(int id)
    {
        var taxa = _repositorioTaxa.SelecionarPorId(id);

        if(taxa is null)
            return Result.Fail("Não foi possível encontrar a taxa.");

        _repositorioTaxa.Excluir(taxa);

        return Result.Ok(taxa);
    }

    public Result<TaxaServico> SelecionarId(int id)
    {
        var taxa = _repositorioTaxa.SelecionarPorId(id);

        if(taxa is null)
            return Result.Fail("Não foi possível encontrar a taxa.");
        
        return Result.Ok(taxa);
    }

    public Result<List<TaxaServico>> SelecionarTodos()
        {
        var taxas = _repositorioTaxa.SelecionarTodos();
    
        if(taxas is null)
            return Result.Fail("Não foi possível encontrar nenhuma taxa.");

        return Result.Ok(taxas);
}
}
