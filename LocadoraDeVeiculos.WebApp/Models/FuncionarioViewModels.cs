using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LocadoraDeVeiculos.WebApp.Models;
public class FormFuncionarioViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do funcionário é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    [DisplayName("Nome Completo")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O salário é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O salário deve ser maior que zero.")]
    public decimal Salario { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A data de admissão é obrigatória.")]
    [DisplayName("Data de Admissão")]
    [DataType(DataType.Date)]
    public DateTime Admissao { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "O login de usuário é obrigatório.")]
    [StringLength(50, ErrorMessage = "O login deve ter no máximo 50 caracteres.")]
    [DisplayName("Login do Usuário")]
    public string LoginUsuario { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 100 caracteres.")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }
}

public class ListarFuncionarioViewModel : FormFuncionarioViewModel { }
