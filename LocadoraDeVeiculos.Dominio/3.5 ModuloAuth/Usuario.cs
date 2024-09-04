using Microsoft.AspNetCore.Identity;

namespace LocadoraDeVeiculos.Dominio.ModuloUsuario;

public class Usuario : IdentityUser<int>
{
    public int? EmpresaId { get; set; }
    public Usuario? Empresa { get; set; }

    public Usuario()
    {
        EmailConfirmed = true;
    }
}