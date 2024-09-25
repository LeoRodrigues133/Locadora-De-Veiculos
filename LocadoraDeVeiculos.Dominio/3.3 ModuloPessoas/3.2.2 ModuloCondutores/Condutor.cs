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
        var erros = new List<string>();

        if (string.IsNullOrEmpty(Nome?.Trim()))
            erros.Add("O nome é obrigatório.");

        if (string.IsNullOrEmpty(Email?.Trim()))
            erros.Add("O email é obrigatório.");

        if (string.IsNullOrEmpty(Telefone?.Trim()))
            erros.Add("O telefone é obrigatório.");

        if (string.IsNullOrEmpty(CNH?.Trim()))
            erros.Add("A CNH é obrigatória.");

        if (ValidadeCNH < DateTime.Now)
            erros.Add("A validade da CNH deve ser uma data futura.");

        if (ClienteCondutor && (string.IsNullOrEmpty(CPF?.Trim()) || CPF.Length != 11))
            erros.Add("O CPF é obrigatório e deve conter 11 dígitos.");

        return erros;
    }

}