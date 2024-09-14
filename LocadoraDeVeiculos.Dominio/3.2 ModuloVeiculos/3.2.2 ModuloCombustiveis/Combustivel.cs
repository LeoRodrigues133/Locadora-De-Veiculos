using LocadoraDeVeiculos.Dominio.ModuloUsuario;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;
public class Combustivel
{
    public int Id { get; set; }
    public DateTime DataCriacao { get; set; }

    public decimal ValorGasolina { get; set; }
    public decimal ValorGas { get; set; }
    public decimal ValorDiesel { get; set; }
    public decimal ValorAlcool { get; set; }

    public int EmpresaId { get; set; }
    public Usuario? Empresa { get; set; }
    protected Combustivel() { }

    public Combustivel(
        decimal valorGasolina,
        decimal valorGas,
        decimal valorDiesel,
        decimal valorAlcool
    ) : this()
    {
        ValorGasolina = valorGasolina;
        ValorGas = valorGas;
        ValorDiesel = valorDiesel;
        ValorAlcool = valorAlcool;
    }

    public decimal ObterValorCombustivel(EnumCombustivel tipoCombustivel)
    {
        return tipoCombustivel switch
        {
            EnumCombustivel.Etanol => ValorAlcool,
            EnumCombustivel.Diesel => ValorDiesel,
            EnumCombustivel.GNV => ValorGas,
            _ => ValorGasolina
        };
    }
}
 