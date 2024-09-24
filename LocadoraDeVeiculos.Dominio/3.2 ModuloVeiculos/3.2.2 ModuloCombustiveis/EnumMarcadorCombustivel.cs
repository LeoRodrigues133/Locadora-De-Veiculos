using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;

public enum EnumMarcadorCombustivel
{
    Vazio,
    [Display(Name = "Um Quarto")] UmQuarto,
    [Display(Name = "Meio Tanque")] MeioTanque,
    [Display(Name = "Três Quartos")] TresQuartos,
    Completo
}
