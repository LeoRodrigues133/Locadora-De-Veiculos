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
}