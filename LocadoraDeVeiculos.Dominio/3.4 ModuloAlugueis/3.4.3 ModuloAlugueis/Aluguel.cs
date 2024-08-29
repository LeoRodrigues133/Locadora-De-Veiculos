using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Dominio;

public class Aluguel : EntidadeBase
{
    public Aluguel(
        int entrada,
        int condutorId,
        int veiculoId,
        int planoId,
        DateTime dataLocacao,
        DateTime? dateDevolucaoPrevista)
    {
        Entrada = entrada;
        CondutorId = condutorId;
        VeiculoId = veiculoId;
        PlanoId = planoId;
        Taxas = new List<TaxaServico>();
        DataLocacao = dataLocacao;
        DateDevolucaoPrevista = dateDevolucaoPrevista;
    }

    public int Entrada { get; set; }
    public Condutor Condutor { get; set; }
    public Veiculo Veiculo { get; set; }
    public Cliente Cliente { get; set; }
    public Plano Plano { get; set; }
    public GrupoVeiculos Grupo {  get; set; }
    public List<TaxaServico> Taxas { get; set; }
    public DateTime DataLocacao { get; set; }
    public DateTime? DateDevolucaoPrevista { get; set; }
    public int PlanoId { get; set; }
    public int VeiculoId { get; set; }
    public int GrupoId { get; set; }
    public int CondutorId { get; set; }
}