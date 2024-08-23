using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;
public class GrupoVeiculos : EntidadeBase
{
    public string Nome { get; set; }
    public List<Veiculo>? Veiculos { get; set; }
    public GrupoVeiculos()
    {
    }
    public GrupoVeiculos(string nome)
    {
        Nome = nome;
        Veiculos = new List<Veiculo>();
    }

    public override string ToString()
    {
        return Nome;
    }
}
