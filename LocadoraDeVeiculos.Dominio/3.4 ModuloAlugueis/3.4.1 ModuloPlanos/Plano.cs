using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Dominio;

public class Plano : EntidadeBase
{
    public Plano() { }
    public Plano(
        TipoPlano tipoPlano,
        decimal valorDiaria,
        decimal precoKM,
        decimal valorExtrapolado,
        int kmDisponivel,
        int grupoVeiculosId)
    {
        TipoPlano = tipoPlano;
        ValorDiaria = valorDiaria;
        PrecoKm = precoKM;
        ValorExtrapolado = valorExtrapolado;
        KmDisponivel = kmDisponivel;
        GrupoVeiculosId = grupoVeiculosId;
    }
    public TipoPlano TipoPlano { get; set; }
    public decimal? ValorDiaria { get; set; }
    public decimal? PrecoKm { get; set; }
    public decimal? ValorExtrapolado { get; set; }
    public int? KmDisponivel { get; set; }
    public GrupoVeiculos GrupoVeiculos { get; set; }
    public int GrupoVeiculosId { get; set; }

    public override List<string> Validar()
    {
        var erros = new List<string>();

        if(TipoPlano == TipoPlano.Diario)
        {

            if (ValorDiaria == null || ValorDiaria <= 0)
                erros.Add("O valor da diária deve ser maior que zero.");

            if (PrecoKm == null || PrecoKm <= 0)
                erros.Add("O preço por KM deve ser maior que zero.");

        }
        else if(TipoPlano == TipoPlano.Controlado)
        {
            if (ValorDiaria == null || ValorDiaria <= 0)
                erros.Add("O valor da diária deve ser maior que zero.");

            if (ValorExtrapolado == null || ValorExtrapolado <= 0)
                erros.Add("O valor extrapolado deve ser maior que zero.");

            if (KmDisponivel == null || KmDisponivel <= 0)
                erros.Add("A quantidade de KM disponível deve ser maior que zero.");

        }else if( TipoPlano == TipoPlano.Livre)
        {
            if (ValorDiaria == null || ValorDiaria <= 0)
                erros.Add("O valor da diária deve ser maior que zero.");
        }

        if (GrupoVeiculosId <= 0)
            erros.Add("O grupo de veículos é obrigatório.");

        if (TipoPlano == null)
            erros.Add("O tipo de plano é obrigatório.");

        return erros;
    }
}
