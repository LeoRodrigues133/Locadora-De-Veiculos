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
    readonly IRepositorioCliente _repositorioCliente;
    readonly IRepositorioAluguel _repositorioAluguel;
    readonly IRepositorioVeiculo _repositorioVeiculo;
    readonly IRepositorioCondutor _repositorioCondutor;
    readonly IRepositorioTaxaEServicos _repositorioTaxa;
    readonly IRepositorioGrupoVeiculos _repositorioGrupoVeiculos;

    public AluguelService(
        IRepositorioPlano repositorioPlano, IRepositorioVeiculo repositorioVeiculo,
        IRepositorioAluguel repositorioAluguel, IRepositorioCliente repositorioCliente,
        IRepositorioCondutor repositorioCondutor, IRepositorioTaxaEServicos repositorioTaxa,
        IRepositorioGrupoVeiculos repositorioGrupoVeiculos)
    {
        _repositorioTaxa = repositorioTaxa;
        _repositorioPlano = repositorioPlano;
        _repositorioVeiculo = repositorioVeiculo;
        _repositorioCliente = repositorioCliente;
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

    public Result<Aluguel> Editar (Aluguel aluguelEditado)
    {
        var aluguelSelecionado = _repositorioAluguel.SelecionarPorId(aluguelEditado.Id);

        #region edit

        aluguelSelecionado.DateDevolucaoPrevista = aluguelEditado.DateDevolucaoPrevista;
        aluguelSelecionado.KmFinal = aluguelEditado.KmFinal;

        #endregion
        _repositorioAluguel.Editar(aluguelSelecionado);

        return Result.Ok(aluguelSelecionado);
    }

    public Result<Aluguel> Excluir(int id)
    {
        var aluguel = _repositorioAluguel.SelecionarPorId(id);

        if( aluguel is null)
            return Result.Fail("Não foi encontrado o aluguel.");

        _repositorioAluguel.Excluir(aluguel);

        return Result.Ok(aluguel);
    }
    public Result<Aluguel> SelecionarId(int id)
    {
        var aluguel = _repositorioAluguel.SelecionarPorId(id);

        BuscarRegistros(aluguel!);

        if (aluguel is null)
            return Result.Fail("Não foi encontrado o aluguel.");

        return Result.Ok(aluguel);
    }

    public Result<List<Aluguel>> SelecionarTodos()
    {
        var alugueis = _repositorioAluguel.SelecionarTodos();
        if (alugueis is null)
            return Result.Fail("Não foi possível encontrar nenhum registro.");

        return Result.Ok(alugueis);
    }

    public Result<Aluguel> Finalizar (Aluguel aluguel)
    {

        var veiculo = aluguel.Veiculo;

        veiculo.Quilometragem += CalcularKm(aluguel);

        _repositorioVeiculo.Editar(veiculo);


        return Result.Ok(aluguel);
    }

    public decimal? CalcularValor(int id)
    {
        var aluguel = _repositorioAluguel.SelecionarPorId(id);

        foreach (var taxa in aluguel.Taxas)
            if (!taxa.TipoDeCobranca)
                aluguel.ValorFinal += taxa.Valor * CalcularDiasAlocado(aluguel);
            else
                aluguel.ValorFinal += taxa.Valor;

        decimal multiplicadorMulta = 1.1M;

        var teste = CalcularDiaria(aluguel, CalcularDiasAlocado(aluguel));

        for (int i = 0; i < CalcularDiasDeAtraso(aluguel); i++)
            aluguel.ValorFinal += teste * multiplicadorMulta;

        return aluguel.ValorFinal;
    }

    private decimal CalcularDiaria(Aluguel aluguel, int Diarias)
    {
        var PlanoDeCobranca = aluguel.Plano.TipoPlano;

        int? KmDisponivel;
        decimal? valorKm;
        decimal? valorKmExtrapolado;
        decimal? valorDiaria;

        switch (PlanoDeCobranca)
        {
            case TipoPlano.Diario:
                valorDiaria = aluguel.Plano.ValorDiaria!;
                valorKm = aluguel.Plano.PrecoKm;


                aluguel.ValorFinal += Diarias * valorDiaria;
                aluguel.ValorFinal += valorKm * CalcularKm(aluguel);

                return (decimal)aluguel.ValorFinal;
                break;

            case TipoPlano.Livre:
                valorDiaria = aluguel.Plano.ValorDiaria!;

                aluguel.ValorFinal += Diarias * valorDiaria;

                return (decimal)aluguel.ValorFinal;

                break;

            case TipoPlano.Controlado:
                valorDiaria = aluguel.Plano.ValorDiaria!;
                valorKmExtrapolado = aluguel.Plano.ValorExtrapolado!;
                KmDisponivel = aluguel.Plano.KmDisponivel;

                int? KmExtrapolado = Math.Abs((int)KmDisponivel )- CalcularKm(aluguel);

                if ((int)KmExtrapolado <= 0)
                    aluguel.ValorFinal += 0;
                else
                    aluguel.ValorFinal += valorKmExtrapolado * KmExtrapolado;

                aluguel.ValorFinal += Diarias * valorDiaria;

                return (decimal)aluguel.ValorFinal;

                break;
        }

        return (decimal)aluguel.ValorFinal!;
    }

    private int CalcularDiasDeAtraso(Aluguel aluguel)
    {
        var DataDeDevolucaoPrevista = aluguel.DateDevolucaoPrevista!.Value.DayOfYear;

        var DataDeDevolucao = aluguel.DateDevolucaoPrevista.Value.DayOfYear;

        var DiasDeAtraso = DataDeDevolucaoPrevista - DataDeDevolucao;

        return DiasDeAtraso;
    }

    private int CalcularKm(Aluguel aluguel)
    {
        var KmInicial = aluguel.Veiculo.Quilometragem;
        var KmFinal = (int)aluguel.KmFinal!;

        var KmPercorrido = KmFinal - KmInicial;

        return KmPercorrido;
    }

    private int CalcularDiasAlocado(Aluguel aluguel)
    {
        var DataDeLocacao = aluguel.DataLocacao.DayOfYear;

        var DataDeDevolucao = aluguel.DateDevolucaoPrevista!.Value.DayOfYear;

        var DiasAlugado = DataDeDevolucao - DataDeLocacao;

        return DiasAlugado;
    }

    private void BuscarRegistros(Aluguel aluguel)
    {
        var condutor = _repositorioCondutor.SelecionarPorId(aluguel.CondutorId);

        aluguel.Condutor = condutor;

        var plano = _repositorioPlano.SelecionarPorId(aluguel.PlanoId);
        var veiculo = _repositorioVeiculo.SelecionarPorId(aluguel.VeiculoId);
        var grupo = _repositorioGrupoVeiculos.SelecionarPorId(aluguel.GrupoId);
        var cliente = _repositorioCliente.SelecionarPorId(condutor.ClienteId);


        aluguel.Plano = plano;
        aluguel.Grupo = grupo;
        aluguel.Veiculo = veiculo;
        aluguel.Cliente = cliente;
    }

    public void salvarTaxas(Aluguel aluguel)
    {
        var aluguelSelecionado = _repositorioAluguel.SelecionarPorId(aluguel.Id);

        aluguelSelecionado.Taxas = aluguel.Taxas;

        _repositorioAluguel.Editar(aluguelSelecionado);
    }
}