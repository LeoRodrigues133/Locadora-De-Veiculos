using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
public class TaxaServico : EntidadeBase
{
    public TaxaServico(
        string nome,
        decimal valor,
        bool tipoDeCobranca)
    {
        Nome = nome;
        Valor = valor;
        TipoDeCobranca = tipoDeCobranca;
        Alugueis = new List<Aluguel>();

    }

    public string Nome {  get; set; }
    public decimal Valor    { get; set; }
    public List<Aluguel> Alugueis { get; set; }
    public bool TipoDeCobranca {  get; set; }
}
