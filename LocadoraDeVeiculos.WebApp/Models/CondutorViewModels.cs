using AutoMapper.Configuration.Annotations;
using LocadoraDeVeiculos.Dominio;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.WebApp.Models;

public class FormCondutorViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "A CNH é obrigatória.")]
    [StringLength(11, ErrorMessage = "A CNH deve ter 11 caracteres.")]
    public string CNH { get; set; }

    [Required(ErrorMessage = "A validade da CNH é obrigatória.")]
    [DataType(DataType.Date)]
    [Display(Name = "Validade da CNH")]
    public DateTime ValidadeCNH { get; set; }

    [Required(ErrorMessage = "O cliente é obrigatório.")]
    public int ClienteId { get; set; }

    [Ignore]
    public Cliente Cliente { get; set; }

    [Ignore]
    public IEnumerable<SelectListItem> Clientes { get; set; }

    [Display(Name = "Cliente é condutor")]
    public bool ClienteCondutor { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string? Nome { get; set; }

    [EmailAddress(ErrorMessage = "Endereço de e-mail inválido.")]
    [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [StringLength(16, ErrorMessage = "O telefone deve ter no máximo 11 caracteres.")]
    public string? Telefone { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [MinLength(14, ErrorMessage = "O CPF deve conter 11 dígitos.")]
    public string? CPF { get; set; }
}

public class ListarCondutorViewModel : FormCondutorViewModel
{
    public Cliente Cliente { get; set; }

    public string DefinirCondutor(string NomeCondutor, Cliente cliente)
    {
        if (NomeCondutor != cliente.Nome)
            return cliente.Nome;

        return "O cliente é o Condutor";
    }

    public string CpfOuCnpj(Cliente cliente)
    {
        if (cliente.CNPJ != null)
            return cliente.CNPJ;

        return cliente.CPF;
    }
}

