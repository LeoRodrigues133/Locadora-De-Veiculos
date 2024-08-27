using Microsoft.Identity.Client;

namespace LocadoraDeVeiculos.WebApp.Models;

public class FormTaxasViewModel
{
    public int Id {  get; set; }
    public string Nome { get; set; }
    public decimal Valor {  get; set; }
    public bool TipoDeCobranca { get; set; }
    //public int AluguelId { get; set; }
}
public class ListarTaxasViewModel : FormTaxasViewModel { }
public class ExcluirTaxasViewModel : FormTaxasViewModel { }
public class DetalhesTaxasViewModel : FormTaxasViewModel { }
public class EditarTaxasViewModel : FormTaxasViewModel { }
public class CadastroTaxasViewModel : FormTaxasViewModel { }
