using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.WebApp.Models;

public class FormTaxasViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo Valor é obrigatório.")]
    [Range(0.01, 10000, ErrorMessage = "O Valor deve ser entre 0,01 e 10.000.")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "O campo Tipo de Cobrança é obrigatório.")]
    public bool TipoDeCobranca { get; set; }
}


public class ListarTaxasViewModel : FormTaxasViewModel { }

