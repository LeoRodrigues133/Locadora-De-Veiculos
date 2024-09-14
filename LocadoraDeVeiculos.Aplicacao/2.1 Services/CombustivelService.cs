
using FluentResults;

namespace LocadoraDeVeiculos.Aplicacao.Services;

using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;

public class ServicoCombustivel
{
    private readonly IRepositorioCombustivel _repositorioCombustivel;

    public ServicoCombustivel(IRepositorioCombustivel repositorioCombustivel)
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
        var config = _repositorioCombustivel.SelecionarPorId(idEmpresa);

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