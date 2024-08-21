using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio;

public class Cliente : EntidadeBase
{
    public Cliente(
        string rG, 
        string nome, 
        string email, 
        string telefone,
        string endereco,
        PerfilCliente perfil)
    {
        RG = rG;
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        Perfil = perfil;
    }

    public string RG { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public PerfilCliente Perfil { get; set; }
}