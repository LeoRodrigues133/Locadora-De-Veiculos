using LocadoraDeVeiculos.Dominio;

namespace LocadoraDeVeiculos.WebApp.Models;

public class FormClienteViewModel
{
    public int Id { get; set; }
    public string RG { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public string? CPF { get; set; }
    public string? CNPJ { get; set; }
    public bool TipoPerfil { get; set; }
}
public class ListarClienteViewModel : FormClienteViewModel
{
    public Cliente Cliente { get; set; }
    public string tipoCliente{ get; set; }
    public string CpfOuCnpf(Cliente cliente)
    {  
        if (cliente == null)
            return "Erro";

        if (cliente.TipoPerfil == false)
            return Cliente.CNPJ;

        return cliente.CPF;
    }
}
public class CadastroClienteViewModel : FormClienteViewModel { }
public class EditarClienteViewModel : FormClienteViewModel { }
public class ExcluirClienteViewModel : FormClienteViewModel { }
public class DetalhesClienteViewModel : FormClienteViewModel { }