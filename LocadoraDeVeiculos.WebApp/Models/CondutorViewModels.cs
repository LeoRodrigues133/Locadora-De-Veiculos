using LocadoraDeVeiculos.Dominio;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.WebApp.Models;

public class FormCondutorViewModel
{
    public int Id { get; set; }
    public string CNH { get; set; }
    public DateTime ValidadeCNH { get; set; }
    public int ClienteId { get; set; }

    [Display(Name = "Cliente é condutor")]
    public bool ClienteCondutor { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string? CPF { get; set; }
}
public class ListarCondutorViewModel : FormCondutorViewModel { }
public class CadastroCondutorViewModel : FormCondutorViewModel
{
    public IEnumerable<SelectListItem>? Clientes { get; set; }
}
public class EditarCondutorViewModel : FormCondutorViewModel
{
    public IEnumerable<SelectListItem>? Clientes { get; set; }
}
public class ExcluirCondutorViewModel : FormCondutorViewModel
{
    public IEnumerable<SelectListItem>? Clientes { get; set; }
}
public class DetalhesCondutorViewModel : FormCondutorViewModel
{
    public Cliente Cliente { get; set; }
}
