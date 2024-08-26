using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio;

public class Condutor : Cliente
{
    public string CNH { get; set; }
    public DateTime ValidadeCNH { get; set; }

    public Condutor(
        string cNH,
        DateTime validadeCNH) : base()
    {
        CNH = cNH;
        ValidadeCNH = validadeCNH;
    }
}