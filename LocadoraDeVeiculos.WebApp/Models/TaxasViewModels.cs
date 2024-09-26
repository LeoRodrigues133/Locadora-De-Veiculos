namespace LocadoraDeVeiculos.WebApp.Models;

public class FormTaxasViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public bool TipoDeCobranca { get; set; }
}
public class ListarTaxasViewModel : FormTaxasViewModel { }

