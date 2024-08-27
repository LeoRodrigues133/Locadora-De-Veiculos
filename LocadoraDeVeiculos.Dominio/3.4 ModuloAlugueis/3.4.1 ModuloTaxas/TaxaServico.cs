using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
public class TaxaServico : EntidadeBase
{
    public TaxaServico(
        string nome,
        decimal valor,
        bool tipoDeCobranca
        /*int aluguelId*/)
    {
        Nome = nome;
        Valor = valor;
        TipoDeCobranca = tipoDeCobranca;
        //AluguelId = alugueilId;

    }

    public string Nome {  get; set; }
    public decimal Valor    { get; set; }
    //public int AluguelId {  get; set; }
    public bool TipoDeCobranca {  get; set; }
}
