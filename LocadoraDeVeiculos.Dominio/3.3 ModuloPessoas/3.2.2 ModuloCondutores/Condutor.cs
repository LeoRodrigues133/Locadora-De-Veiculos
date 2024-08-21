using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio;

public class Condutor : Cliente
{
    public Condutor( 
        string cnh,
        string rG,
        string nome, 
        string email, 
        string telefone, 
        string endereco, 
        DateTime validadeCnh,
        PerfilCliente perfil) 
        : base(rG, nome, email, telefone, endereco, perfil)
    {
        CNH = cnh;
        ValidadeCNH = validadeCnh;
    }

    public string CNH { get; set; }
    public DateTime ValidadeCNH { get; set; }
}