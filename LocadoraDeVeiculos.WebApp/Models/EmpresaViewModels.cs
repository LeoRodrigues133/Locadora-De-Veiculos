using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.WebApp.Models;

public class RegistrarEmpresaViewModel
{
    [Required]
    public string? Usuario { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Senha { get; set; }

    [Display(Name = "Confirme a senha")]
    [DataType(DataType.Password)]
    [Compare("Senha", ErrorMessage = "As senhas não conferem")]
    public string? ConfirmarSenha { get; set; }
}

public class LoginEmpresaViewModel
{
    [Required]
    public string? Usuario { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    [DataType(DataType.Password)]
    public string? Senha { get; set; }
    [DisplayName("Lembrar-Me")]
    public bool LembrarMe { get; set; }
}