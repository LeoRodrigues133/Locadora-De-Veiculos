using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeVeiculos.WebApp.Models;

public abstract class formGrupoViewModel
{
    public int Id {  get; set; }
    public string Nome { get; set; }
}

public class CadastroGrupoViewModel : formGrupoViewModel
{
}
public class ListarGrupoViewModel : formGrupoViewModel
{
    public IEnumerable<SelectListItem> Grupos { get; set; }
}
public class EditarGrupoViewModel : formGrupoViewModel
{
}
public class ExcluirGrupoViewModel : formGrupoViewModel
{
}
public class DetalhesGrupoViewModel : formGrupoViewModel
{
}
