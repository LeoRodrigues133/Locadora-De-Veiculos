using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Dominio;

public class Plano : EntidadeBase
{
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
        PrecoKM = precoKM;
        ValorExtrapolado = valorExtrapolado;
        KmDisponivel = kmDisponivel;
        GrupoVeiculosId = grupoVeiculosId;
    }
    public Plano()
    {
        
    }
    public TipoPlano TipoPlano {  get; set; }
    public decimal? ValorDiaria { get; set; }
    public decimal? PrecoKM { get; set; }
    public decimal? ValorExtrapolado { get; set; }
    public int? KmDisponivel {  get; set; }
    public GrupoVeiculos GrupoVeiculos { get; set; }
    public int GrupoVeiculosId { get; set; }

}