using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.WebApp.Models;

public class FormVeiculoViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O veículo está Alugado.")]
    public bool Alugado { get; set; }

    [Required(ErrorMessage = "A Cor é obrigatória.")]
    public Cor Cor { get; set; }

    [Required(ErrorMessage = "A Marca é obrigatória.")]
    public Marca Marca { get; set; }

    [Required(ErrorMessage = "O Combustível é obrigatório.")]
    public EnumCombustivel Combustivel { get; set; }

    [Required(ErrorMessage = "O Ano é obrigatório.")]
    [Range(1900, 2100, ErrorMessage = $"O Ano deve estar entre 1900 e 2100.")]
    public int Ano { get; set; }

    [Required(ErrorMessage = "A Placa é obrigatória.")]
    [StringLength(10, ErrorMessage = "A Placa pode ter no máximo 10 caracteres.")]
    public string Placa { get; set; }

    [Required(ErrorMessage = "O Modelo é obrigatório.")]
    [StringLength(20, ErrorMessage = "O Modelo pode ter no máximo 20 caracteres.")]
    public string Modelo { get; set; }

    [Required(ErrorMessage = "A Quilometragem é obrigatória.")]
    [Range(0, int.MaxValue, ErrorMessage = "A Quilometragem deve ser um valor positivo.")]
    public int Quilometragem { get; set; }

    [Required(ErrorMessage = "O veículo deve ser registrado em um grupo.")]
    [DisplayName("Grupo de Veículo")]
    public int grupoVeiculosId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "A Capacidade do Tanque de Combustível deve ser um valor positivo.")]
    [DisplayName("Capacidade de combustivel")]
    [Required(ErrorMessage = "A Capacidade do Tanque de Combustível é obrigatória.")]
    public int CapacidadeTanqueDeCombustivel { get; set; }

    [DisplayName("Grupo de Veículos")]
    public IEnumerable<SelectListItem>? GrupoVeiculos { get; set; }

    //[Required(ErrorMessage = "A foto é obrigatória")]
    //public IFormFile Foto { get; set; }
}

public class ListarVeiculoViewModel : FormVeiculoViewModel
{
    public string Alugado { get; set; }
    public GrupoVeiculos GrupoVeiculos { get; set; }
}