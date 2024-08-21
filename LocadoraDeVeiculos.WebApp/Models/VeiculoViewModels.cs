using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.WebApp.Models;

public abstract class FormVeiculoViewModel
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "O veículo está Alugado.")]
    public bool Alugado { get; set; }

    [Required(ErrorMessage = "A Cor é obrigatória.")]
    public Cor Cor { get; set; }

    [Required(ErrorMessage = "A Marca é obrigatória.")]
    public Marca Marca { get; set; }

    [Required(ErrorMessage = "O Tipo de CNH é obrigatório.")]
    public CategoriaVeiculo CategoriaVeiculo { get; set; }

    [Required(ErrorMessage = "O Combustível é obrigatório.")]
    public Combustivel Combustivel { get; set; }

    [Required(ErrorMessage = "O Ano é obrigatório.")]
    [Range(1900, 2100, ErrorMessage = "O Ano deve estar entre 1900 e 2100.")]
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

    [Required(ErrorMessage = "A Capacidade do Tanque de Combustível é obrigatória.")]
    [Range(1, int.MaxValue, ErrorMessage = "A Capacidade do Tanque de Combustível deve ser um valor positivo.")]
    public int CapacidadeTanqueDeCombustivel { get; set; }

}

public class CadastroVeiculoViewModel : FormVeiculoViewModel
{
    public Veiculo? Veiculo { get; set; }
}
public class EditarVeiculoViewModel : FormVeiculoViewModel
{
    public int Id { get; set; }
}
public class DetalhesVeiculoViewModel : FormVeiculoViewModel
{
    public int Id {  get; set; }
    public Veiculo? Veiculo{ get; set; }
}
public class ListarVeiculoViewModel
{
    public int Id { get; set; }
    public string Alugado { get; set; }
    public string Modelo { get; set; }
    public string Placa { get; set; }
    public string Cor { get; set; }
    public string CategoriaVeiculo { get; set; }
    public string Marca { get; set; }
    public string Ano { get; set; }
    public string TipoCnh { get; set; }
    public string Combustivel { get; set; }
    public string Quilometragem { get; set; }
    public string CapacidadeTanqueDeCombustivel { get; set; }
}