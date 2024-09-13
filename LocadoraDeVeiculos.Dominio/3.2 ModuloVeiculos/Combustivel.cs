using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;
public class Combustivel : EntidadeBase
{
    public EnumCombustivel Nome {  get; set; }
    public decimal Preco { get; set; }

    public Combustivel(){}

    public Combustivel(EnumCombustivel nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }
}
