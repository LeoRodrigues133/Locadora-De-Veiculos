using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeVeiculos.WebApp.Models;

public class FormGrupoViewModel
{
    public int Id {  get; set; }
    public string Nome { get; set; }
}

public class CadastroGrupoViewModel : FormGrupoViewModel
{
}
public class ListarGrupoViewModel : FormGrupoViewModel
{
    public IEnumerable<SelectListItem> Grupos { get; set; }
}
public class EditarGrupoViewModel : FormGrupoViewModel
{
}
public class ExcluirGrupoViewModel : FormGrupoViewModel
{
}
public class DetalhesGrupoViewModel : FormGrupoViewModel
{
}
