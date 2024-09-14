using FluentResults;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloClientes;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloAlugueis;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloCondutores;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;

namespace LocadoraDeVeiculos.Aplicacao.Services;
public class AluguelService
{
    readonly IRepositorioPlano _repositorioPlano;
    readonly IRepositorioCliente _repositorioCliente;
    readonly IRepositorioAluguel _repositorioAluguel;
    readonly IRepositorioVeiculo _repositorioVeiculo;
    readonly IRepositorioCondutor _repositorioCondutor;
    readonly IRepositorioTaxaEServicos _repositorioTaxa;
    readonly IRepositorioCombustivel _repositorioCombustivel;
    readonly IRepositorioGrupoVeiculos _repositorioGrupoVeiculos;

    public AluguelService(
        IRepositorioPlano repositorioPlano, IRepositorioVeiculo repositorioVeiculo,
        IRepositorioAluguel repositorioAluguel, IRepositorioCliente repositorioCliente,
        IRepositorioCondutor repositorioCondutor, IRepositorioTaxaEServicos repositorioTaxa,
        IRepositorioGrupoVeiculos repositorioGrupoVeiculos, IRepositorioCombustivel repositioCombustivel)
    {
        _repositorioTaxa = repositorioTaxa;
        _repositorioPlano = repositorioPlano;
        _repositorioVeiculo = repositorioVeiculo;
        _repositorioCliente = repositorioCliente;
        _repositorioAluguel = repositorioAluguel;
        _repositorioCondutor = repositorioCondutor;
        _repositorioCombustivel = repositioCombustivel;
        _repositorioGrupoVeiculos = repositorioGrupoVeiculos;
    }
    public Result<Aluguel> Cadastrar(Aluguel aluguel)
    {
        var ValorCombustivelEmpres = _repositorioCombustivel.SelecionarPorId(aluguel.EmpresaId);

        BuscarRegistros(aluguel);

        _repositorioAluguel.Cadastrar(aluguel);

        return Result.Ok(aluguel);
    }

    public Result<Aluguel> Excluir(int id)
    {
        var aluguel = _repositorioAluguel.SelecionarPorId(id);

        if( aluguel is null)
            return Result.Fail("Não foi encontrado o aluguel.");

        _repositorioAluguel.Excluir(aluguel);

        return Result.Ok(aluguel);
    }

    public Result<Aluguel> Finalizar (Aluguel aluguel)
    {
        var QuilometragemDeSaida = aluguel.Veiculo.Quilometragem;
        aluguel.Veiculo.Quilometragem += QuilometrosPercorrido(aluguel);

        aluguel.FinalizarLocacao();
        
        _repositorioVeiculo.Editar(aluguel.Veiculo);
        _repositorioAluguel.Editar(aluguel);

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
                aluguel.ValorFinal += valorKm * QuilometrosPercorrido(aluguel);

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

                int? KmExtrapolado = Math.Abs((int)KmDisponivel )- QuilometrosPercorrido(aluguel);

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

    private int DiasDeAtraso(Aluguel aluguel)
    {
        var DataDeDevolucaoPrevista = aluguel.DateDevolucaoPrevista!.Value.DayOfYear;

        var DataDeDevolucao = DateTime.Now.DayOfYear;

        var DiasDeAtraso = DataDeDevolucao - DataDeDevolucaoPrevista;

        return DiasDeAtraso;
    }

    private int QuilometrosPercorrido(Aluguel aluguel)
    {
        var KmInicial = aluguel.Veiculo.Quilometragem;
        var KmFinal = (int)aluguel.KmFinal!;

        var KmPercorrido = KmFinal - KmInicial;

        return KmPercorrido;
    }

    private int DiasLocado(Aluguel aluguel)
    {
        var DataDeLocacao = aluguel.DataLocacao.DayOfYear;

        var DataDeDevolucao = aluguel.DateDevolucaoPrevista!.Value.DayOfYear;

        var DiasAlugado = DataDeDevolucao - DataDeLocacao;

        return DiasAlugado;
    }

    public decimal? CalcularValor(int id)
    {
        decimal MultiplicadorDeMulta = .1m;

        var aluguel = _repositorioAluguel.SelecionarPorId(id);

        foreach (var taxa in aluguel.Taxas)
            if (!taxa.TipoDeCobranca)
                aluguel.ValorFinal += taxa.Valor * DiasLocado(aluguel);
            else
                aluguel.ValorFinal += taxa.Valor;

        var ValorTotalDiaria = CalcularDiaria(aluguel, DiasLocado(aluguel));

        for (int i = 0; i < DiasDeAtraso(aluguel); i++)
            aluguel.ValorFinal += ValorTotalDiaria * MultiplicadorDeMulta;

        return aluguel.ValorFinal;
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

    public void SalvarKM(Aluguel aluguel)
    {
        _repositorioAluguel.Editar(aluguel);
    }
}