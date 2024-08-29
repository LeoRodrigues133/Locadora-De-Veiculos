using FluentResults;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloClientes;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloAlugueis;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloCondutores;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Aplicacao.Services;
public class AluguelService
{
    readonly IRepositorioPlano _repositorioPlano;
    readonly IRepositorioVeiculo _repositorioVeiculo;
    readonly IRepositorioCondutor _repositorioCondutor;
    readonly IRepositorioTaxaEServicos _repositorioTaxa;
    readonly IRepositorioGrupoVeiculos _repositorioGrupoVeiculos;
    readonly IRepositorioAluguel _repositorioAluguel;

    public AluguelService(
        IRepositorioPlano repositorioPlano, IRepositorioVeiculo repositorioVeiculo,
        IRepositorioCliente repositorioCliente, IRepositorioCondutor repositorioCondutor,
        IRepositorioTaxaEServicos repositorioTaxa, IRepositorioGrupoVeiculos repositorioGrupoVeiculos, IRepositorioAluguel repositorioAluguel)
    {
        _repositorioTaxa = repositorioTaxa;
        _repositorioPlano = repositorioPlano;
        _repositorioVeiculo = repositorioVeiculo;
        _repositorioAluguel = repositorioAluguel;
        _repositorioCondutor = repositorioCondutor;
        _repositorioGrupoVeiculos = repositorioGrupoVeiculos;
    }
    public Result<Aluguel> Cadastrar(Aluguel aluguel)
    {
        BuscarRegistros(aluguel);

        _repositorioAluguel.Cadastrar(aluguel);

        return Result.Ok(aluguel);
    }

    public Result<List<Aluguel>> SelecionarTodos()
    {
        var alugueis = _repositorioAluguel.SelecionarTodos();

        if (alugueis is null)
            return Result.Fail("Não foi possível encontrar nenhum registro.");

        return Result.Ok(alugueis);
    }

    private void BuscarRegistros(Aluguel aluguel)
    {
        var plano = _repositorioPlano.SelecionarPorId(aluguel.PlanoId);
        var veiculo = _repositorioVeiculo.SelecionarPorId(aluguel.VeiculoId);
        var grupo = _repositorioGrupoVeiculos.SelecionarPorId(aluguel.GrupoId);
        var condutor = _repositorioCondutor.SelecionarPorId(aluguel.CondutorId);

        aluguel.Plano = plano;
        aluguel.Veiculo = veiculo;
        aluguel.Grupo = grupo;
        aluguel.Condutor = condutor;
    }
}