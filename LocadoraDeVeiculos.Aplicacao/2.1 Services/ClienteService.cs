using FluentResults;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloClientes;

namespace LocadoraDeVeiculos.Aplicacao.Services;
public class ClienteService
{
    readonly IRepositorioCliente _repositorioClientes;

    public ClienteService(IRepositorioCliente repositorioCliente)
    {
        _repositorioClientes = repositorioCliente;
    }

    public Result<Cliente> Cadastrar(Cliente cliente)
    {
        _repositorioClientes.Cadastrar(cliente);

        return Result.Ok(cliente);
    }
    public Result<Cliente> Editar(Cliente clienteEditado)
    {

        var clienteSelecionado = _repositorioClientes.SelecionarPorId(clienteEditado.Id);

        if (clienteSelecionado is null)
            return Result.Fail("O cliente não foi encontrado");

        #region edit
        clienteSelecionado.RG = clienteEditado.RG;
        clienteSelecionado.CPF = clienteEditado.CPF;
        clienteSelecionado.CNPJ = clienteEditado.CNPJ;
        clienteSelecionado.Nome = clienteEditado.Nome;
        clienteSelecionado.Email = clienteEditado.Email;
        clienteSelecionado.Telefone = clienteEditado.Telefone;
        clienteSelecionado.Endereco = clienteEditado.Endereco;
        clienteSelecionado.TipoPerfil = clienteEditado.TipoPerfil;
        #endregion

        _repositorioClientes.Editar(clienteSelecionado);

        return Result.Ok(clienteSelecionado);
    }
    public Result<Cliente> Excluir(int id)
    {
        var cliente = _repositorioClientes.SelecionarPorId(id);

        if(cliente is null)
            return Result.Fail("O cliente não foi encontrado");

        _repositorioClientes.Excluir(cliente);

        return Result.Ok(cliente);
    }
    public Result<Cliente> SelecionarId(int id)
    {

        var cliente = _repositorioClientes.SelecionarPorId(id);

        if (cliente is null)
            return Result.Fail("O cliente não foi encontrado");

        return Result.Ok(cliente);
    }
    public Result<List<Cliente>> SelecionarTodos()
    {

        var clientes = _repositorioClientes.SelecionarTodos();

        return Result.Ok(clientes);
    }


}
