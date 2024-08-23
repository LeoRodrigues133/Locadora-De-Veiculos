using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.WebApp.Models;

public class FormPlanoViewModels
{
    public int? Id { get; set; }

    public decimal? ValorDiaria { get; set; }

    public decimal? PrecoKm { get; set; }

    public decimal? ValorExtrapolado { get; set; }

    public int? kmDisponivel { get; set; }

    [Required(ErrorMessage = "O veículo deve ser registrado em um grupo.")]
    [DisplayName("Grupo de Veículo")]
    public int grupoVeiculosId { get; set; }

    [DisplayName("Grupo de Veículos")]
    public IEnumerable<SelectListItem>? GrupoVeiculos { get; set; }

}

public class CadastroPlanoViewModel : FormPlanoViewModels { }
public class ListarPlanoViewModel : FormPlanoViewModels { 

    public GrupoVeiculos GrupoVeiculos { get; set;}
}
public class ExcluirPlanoViewModel : FormPlanoViewModels { }
public class EditarPlanoViewModel : FormPlanoViewModels { }
public class DetalhesPlanoViewModel: FormPlanoViewModels { }