using Microsoft.Identity.Client;

namespace LocadoraDeVeiculos.WebApp.Models;

public class FormFuncionarioViewModel {

    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Salario {  get; set; }
    public string Email {  get; set; }
    public DateTime Adimissao { get; set; }
    public string LoginUsuario { get; set; }
    public string Senha { get; set; }
}
public class ListarFuncionarioViewModel : FormFuncionarioViewModel { }
public class CadastroFuncionarioViewModel : FormFuncionarioViewModel
{

}
public class EditarFuncionarioViewModel : FormFuncionarioViewModel { }
public class ExcluirFuncionarioViewModel : FormFuncionarioViewModel { }
