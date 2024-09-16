namespace LocadoraDeVeiculos.Aplicacao.Services;

using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;

public class CombustivelService
{
    private readonly IRepositorioCombustivel _repositorioCombustivel;

    public CombustivelService(IRepositorioCombustivel repositorioCombustivel)
    {
        _repositorioCombustivel = repositorioCombustivel;
    }

    public Result SalvarConfiguracao(Combustivel configuracao)
    {
        configuracao.DataCriacao = DateTime.Now;

       _repositorioCombustivel.Gravar(configuracao);

        return Result.Ok();
    }

    public Result<Combustivel> ObterConfiguracao(int idEmpresa)
    {
        var config = _repositorioCombustivel.SelecionarIdPorEmpresa(idEmpresa);

        if (config is null)
        {
            config = new Combustivel(
                valorAlcool: 0.0m,
                valorDiesel: 0.0m,
                valorGas: 0.0m,
                valorGasolina: 0.0m
            );
        }

        return Result.Ok(config);
    }
}