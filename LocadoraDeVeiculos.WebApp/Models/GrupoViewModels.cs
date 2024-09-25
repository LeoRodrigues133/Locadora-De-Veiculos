using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.WebApp.Models;

public class FormGrupoViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do grupo é obrigatório.")]
    [StringLength(20, ErrorMessage = "O nome do grupo não pode exceder 20 caracteres.")]
    public string Nome { get; set; }
}

public class ListarGrupoViewModel : FormGrupoViewModel
{
    [Required(ErrorMessage = "É necessário selecionar pelo menos um grupo.")]
    public IEnumerable<SelectListItem> Grupos { get; set; }
}