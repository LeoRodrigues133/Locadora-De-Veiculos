using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;

namespace LocadoraDeVeiculos.Dominio;

public class Aluguel : EntidadeBase
{
    public Aluguel()
    {
        Taxas = new List<TaxaServico>();
    }
    public Aluguel(
        int entrada,
        int planoId,
        int veiculoId,
        int clienteId,
        int grupoId,
        int condutorId,
        int? kmFinal,
        int combustivelId,
        decimal valorFinal,
        DateTime dataLocacao,
        DateTime? dateDevolucaoPrevista,
        EnumMarcadorCombustivel marcadorCombustivel)
    {
        GrupoId = grupoId;
        PlanoId = planoId;
        Entrada = entrada;
        Encerrado = false;
        VeiculoId = veiculoId;
        ClienteId = clienteId;
        CondutorId = condutorId;
        ValorFinal = valorFinal;
        CombustivelId = combustivelId;
        DataLocacao = dataLocacao;
        KmFinal = kmFinal;
        Taxas = new List<TaxaServico>();
        DateDevolucaoPrevista = dateDevolucaoPrevista;
        marcadorCombustivel = EnumMarcadorCombustivel.Completo;

    }
    public bool Encerrado { get; set; }
    public int Entrada { get; set; }
    public decimal? ValorFinal { get; set; }
    public int? KmFinal { get; set; }
    public Plano Plano { get; set; }
    public Veiculo Veiculo { get; set; }
    public Cliente Cliente { get; set; }
    public Condutor Condutor { get; set; }
    public Combustivel Combustivel { get; set; }
    public GrupoVeiculos Grupo { get; set; }
    public DateTime DataLocacao { get; set; }
    public List<TaxaServico> Taxas { get; set; }
    public DateTime? DateDevolucaoPrevista { get; set; }
    public EnumMarcadorCombustivel marcadorCombustivel { get; set; }
    public int GrupoId { get; set; }
    public int PlanoId { get; set; }
    public int VeiculoId { get; set; }
    public int ClienteId { get; set; }
    public int CondutorId { get; set; }
    public int CombustivelId { get; set; }

    public void FinalizarLocacao()
    {
        Encerrado = true;
        ValorFinal = CalcularValorParcial(DiasLocado());

    }
    private decimal CalcularDiaria(int Diarias, int? distancia)
    {
        decimal? valorParcial = 0;

        var PlanoDeCobranca = Plano.TipoPlano;

        int? KmDisponivel;
        decimal? valorKm;
        decimal? valorKmExtrapolado;
        decimal? valorDiaria;

        switch (PlanoDeCobranca)
        {
            case TipoPlano.Diario:
                valorDiaria = Plano.ValorDiaria!;
                valorKm = Plano.PrecoKm;


                valorParcial += Diarias * valorDiaria;

                if (QuilometrosPercorrido() > 0)
                    valorParcial += valorKm * distancia;

                return (decimal)valorParcial;

            case TipoPlano.Livre:
                valorDiaria = Plano.ValorDiaria!;

                valorParcial += Diarias * valorDiaria;

                return (decimal)valorParcial;

            case TipoPlano.Controlado:
                valorDiaria = Plano.ValorDiaria!;
                valorKmExtrapolado = Plano.ValorExtrapolado!;
                KmDisponivel = Plano.KmDisponivel;

                int? KmExtrapolado = Math.Abs((int)KmDisponivel) - QuilometrosPercorrido();

                if ((int)KmExtrapolado <= 0)
                    valorParcial += 0;
                else
                    valorParcial += valorKmExtrapolado * KmExtrapolado;

                valorParcial += Diarias * valorDiaria;

                return (decimal)valorParcial;

        }

        return (decimal)valorParcial!;
    }

    private int DiasDeAtraso()
    {
        var DataDeDevolucaoPrevista = DateDevolucaoPrevista!.Value.DayOfYear;

        var DataDeDevolucao = DateTime.Now.DayOfYear;

        var DiasDeAtraso = DataDeDevolucao - DataDeDevolucaoPrevista;

        return DiasDeAtraso;
    }

    public int QuilometrosPercorrido()
    {
        var KmInicial = Veiculo.Quilometragem;
        var KmFinal = (int)this.KmFinal!;

        var KmPercorrido = KmFinal - KmInicial;

        return KmPercorrido;
    }

    private int DiasLocado()
    {
        var DataDeLocacao = DataLocacao.DayOfYear;

        var DataDeDevolucao = DateDevolucaoPrevista!.Value.DayOfYear;

        var DiasAlugado = DataDeDevolucao - DataDeLocacao;

        return DiasAlugado;
    }

    //public decimal? CalcularValorTotal()
    //{
    //    ValorFinal = CalcularValorParcial();

    //    return ValorFinal;
    //}

    public decimal? CalcularValorParcial(int? distancia)
    {
        decimal valorParcial = 0;

        decimal MultiplicadorDeMulta = .1m;

        foreach (var taxa in Taxas)
            if (!taxa.TipoDeCobranca)
                valorParcial += taxa.Valor * DiasLocado();
            else
                valorParcial += taxa.Valor;

        var ValorTotalDiaria = CalcularDiaria(DiasLocado(), distancia);

        valorParcial += ValorTotalDiaria;

        for (int i = 0; i < DiasDeAtraso(); i++)
            valorParcial += ValorTotalDiaria * MultiplicadorDeMulta;

        valorParcial += CalcularValorDeAbastecimento();

        return valorParcial;
    }
    public decimal CalcularValorDeAbastecimento()
    {

        decimal TotalAbastecimento = 0;

        if (Veiculo is not null && Combustivel is not null)
        {
            var valorCombustivel = Combustivel.ObterValorCombustivel(Veiculo.Combustivel);

            TotalAbastecimento = Veiculo.CalcularLitrosParaAbastecimento(marcadorCombustivel) * valorCombustivel;

            return TotalAbastecimento;

        }

        return TotalAbastecimento;
    }
    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
}