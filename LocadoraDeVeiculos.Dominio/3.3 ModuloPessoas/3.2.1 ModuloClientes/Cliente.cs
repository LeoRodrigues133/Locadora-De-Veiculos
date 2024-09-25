using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio;

public class Cliente : EntidadeBase
{
    public Cliente()
    {
    }

    public Cliente(
        string rG,
        string nome,
        string email,
        string telefone,
        string endereco,
        bool tipoPerfil,
        string? cPF,
        string? cNPJ)
    {
        RG = rG;
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        TipoPerfil = tipoPerfil;
        CPF = cPF;
        CNPJ = cNPJ;
    }

    public string RG { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public bool TipoPerfil { get; set; }
    public string? CPF { get; set; }
    public string? CNPJ { get; set; }

    public override List<string> Validar()
    {
        var erros = new List<string>();

        if (string.IsNullOrEmpty(Nome.Trim()))
            erros.Add("O nome é obrigatório.");

        if (string.IsNullOrEmpty(Email.Trim()))
            erros.Add("O email é obrigatório.");

        if (string.IsNullOrEmpty(Telefone.Trim()))
            erros.Add("O telefone é obrigatório.");

        if (TipoPerfil && (string.IsNullOrEmpty(CPF?.Trim()) || CPF.Length != 11))
            erros.Add("O CPF é obrigatório e deve conter 11 dígitos.");

        if (!TipoPerfil && (string.IsNullOrEmpty(CNPJ?.Trim()) || CNPJ.Length != 14))
            erros.Add("O CNPJ é obrigatório e deve conter 14 dígitos.");

        if (string.IsNullOrEmpty(Endereco.Trim()))
            erros.Add("O endereço é obrigatório.");

        return erros;
    }

}