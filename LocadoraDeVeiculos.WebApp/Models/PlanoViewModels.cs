using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio;

namespace LocadoraDeVeiculos.WebApp.Models;

public class FormPlanoViewModels
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O tipo de plano é obrigatório.")]
    [DisplayName("Tipo de Plano")]
    public TipoPlano TipoPlano { get; set; }

    [Required(ErrorMessage = "O valor da diária é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor da diária deve ser maior que zero.")]
    [DisplayName("Valor da Diária")]
    public decimal? ValorDiaria { get; set; }

    [Required(ErrorMessage = "O preço por Km é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço por Km deve ser maior que zero.")]
    [DisplayName("Preço por Km")]
    public decimal? PrecoKm { get; set; }

    [Required(ErrorMessage = "O valor extrapolado é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor extrapolado deve ser maior que zero.")]
    [DisplayName("Valor Extrapolado")]
    public decimal? ValorExtrapolado { get; set; }

    [Required(ErrorMessage = "A quantidade de Km disponível é obrigatória.")]
    [Range(0, int.MaxValue, ErrorMessage = "A quantidade de Km disponível deve ser um valor positivo.")]
    [DisplayName("Km Disponível")]
    public int? kmDisponivel { get; set; }

    [Required(ErrorMessage = "O veículo deve ser registrado em um grupo.")]
    [DisplayName("Grupo de Veículo")]
    public int grupoVeiculosId { get; set; }

    [DisplayName("Grupo de Veículos")]
    public IEnumerable<SelectListItem>? GrupoVeiculos { get; set; }
}

public class ListarPlanoViewModel : FormPlanoViewModels
{
    public TipoPlano TipoPlano { get; set; }

    public GrupoVeiculos GrupoVeiculos { get; set; }
    public string OcultarValoresNulos<t>(t valor)
    {
        if (valor is decimal d)
            return d != 0 ? d.ToString("C") : "--";

        else if (valor is int i)
            return i != 0 ? i.ToString() : "--";

        return "erro";
    }
}
