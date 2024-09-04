using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.Dominio.ModuloAuth;

public enum TipoUsuarioEnum
{
    Empresa,
    [Display(Name = "Funcionário")] Funcionario
}