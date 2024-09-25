using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
public class TaxaServico : EntidadeBase
{
    public TaxaServico()
    {
    }
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

    public override List<string> Validar()
    {
        var erros = new List<string>();

        if (string.IsNullOrEmpty(Nome.Trim()))
            erros.Add("O nome da taxa é obrigatório.");

        if (Valor <= 0)
            erros.Add("O valor da taxa deve ser maior que zero.");

        return erros;
    }
}
