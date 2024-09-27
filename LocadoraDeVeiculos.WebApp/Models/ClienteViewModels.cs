using LocadoraDeVeiculos.Dominio;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.WebApp.Models;

public class FormClienteViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O RG é obrigatório.")]
    [MinLength(9, ErrorMessage = "O RG deve conter 7 caracteres.")]
    public string RG { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O e-mail não é válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [Phone(ErrorMessage = "O telefone não é válido.")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O endereço é obrigatório.")]
    public string Endereco { get; set; }

    [MinLength(14, ErrorMessage = "O CPF deve conter 11 dígitos.")]
    public string? CPF { get; set; }

    [MinLength(18, ErrorMessage = "O CNPJ deve conter 14 dígitos.")]
    public string? CNPJ { get; set; }

    [Required(ErrorMessage = "O tipo de perfil é obrigatório.")]
    public bool TipoPerfil { get; set; } // False = Pessoa Jurídica, True = Pessoa Física
}

public class ListarClienteViewModel : FormClienteViewModel
{
    public Cliente Cliente { get; set; }
    public string TipoCliente => Cliente.TipoPerfil ? "Pessoa Física" : "Pessoa Jurídica";

    public string CpfOuCnpj(Cliente cliente)
    {
        if (cliente == null)
            return "Erro";

        return cliente.TipoPerfil ? cliente.CPF : cliente.CNPJ;
    }
}
