using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Dominio;

public class Plano : EntidadeBase
{
    public Plano(
        decimal valorDiaria,
        decimal precoKM,
        decimal valorExtrapolado,
        int kmDisponivel,
        int grupoVeiculosId)
    {
        ValorDiaria = valorDiaria;
        PrecoKM = precoKM;
        ValorExtrapolado = valorExtrapolado;
        KmDisponivel = kmDisponivel;
        GrupoVeiculosId = grupoVeiculosId;
    }
    public Plano()
    {
        
    }
    public decimal? ValorDiaria { get; set; }
    public decimal? PrecoKM { get; set; }
    public decimal? ValorExtrapolado { get; set; }
    public int? KmDisponivel {  get; set; }
    public GrupoVeiculos GrupoVeiculos { get; set; }
    public int GrupoVeiculosId { get; set; }

}