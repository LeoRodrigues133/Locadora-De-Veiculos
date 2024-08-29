using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Dominio;

public class Aluguel : EntidadeBase
{
    public Aluguel()
    {
        
    }
    public Aluguel(
        int entrada,
        int planoId,
        int veiculoId,
        int clienteId,
        int grupoId,
        int condutorId,
        DateTime dataLocacao,
        DateTime? dateDevolucaoPrevista)
    {
        GrupoId = grupoId;
        PlanoId = planoId;
        Entrada = entrada;
        VeiculoId = veiculoId;
        ClienteId = clienteId;
        CondutorId = condutorId;
        DataLocacao = dataLocacao;
        Taxas = new List<TaxaServico>();
        DateDevolucaoPrevista = dateDevolucaoPrevista;
    }

    public int Entrada { get; set; }
    public Plano Plano { get; set; }
    public Veiculo Veiculo { get; set; }
    public Cliente Cliente { get; set; }
    public Condutor Condutor { get; set; }
    public GrupoVeiculos Grupo {  get; set; }
    public DateTime DataLocacao { get; set; }
    public List<TaxaServico> Taxas { get; set; }
    public DateTime? DateDevolucaoPrevista { get; set; }
    public int GrupoId { get; set; }
    public int PlanoId { get; set; }
    public int VeiculoId { get; set; }
    public int ClienteId { get; set; }
    public int CondutorId { get; set; }
}