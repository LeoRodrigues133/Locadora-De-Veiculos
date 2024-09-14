using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio;

public class Condutor : EntidadeBase
{
    public Condutor()
    {
        
    }
    public Condutor(
        string cNH,
        DateTime validadeCNH,
        bool clienteCondutor,
        int clienteId,
        string? nome,
        string? email,
        string? telefone,
        string? cPF)
    {
        CNH = cNH;
        ValidadeCNH = validadeCNH;
        ClienteCondutor = clienteCondutor;
        ClienteId = clienteId;
        Nome = nome;
        Email = email;
        Telefone = telefone;
        CPF = cPF;
    }

    public string CNH { get; set; }
    public DateTime ValidadeCNH { get; set; }
    public Cliente Cliente { get; set; }
    public bool ClienteCondutor {  get; set; }
    public int ClienteId { get; set; }
    public string? Nome {  get; set; }
    public string? Email {  get; set; }
    public string? Telefone {  get; set; }
    public string? CPF {  get; set; }

    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
}