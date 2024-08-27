using FluentResults;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloClientes;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloCondutores;

namespace LocadoraDeVeiculos.Aplicacao.Services;
public class CondutorService
{
    readonly IRepositorioCondutor _repositorioCondutor;
    readonly IRepositorioCliente _repositorioCliente;
    public CondutorService(
        IRepositorioCondutor repositorioCondutor,
        IRepositorioCliente repositorioCliente)
    {
        _repositorioCondutor = repositorioCondutor;
        _repositorioCliente = repositorioCliente;
    }

    public Result<Condutor> Cadastrar(Condutor condutor)
    {
        
        var cliente = _repositorioCliente.SelecionarPorId(condutor.ClienteId);

        if (cliente is null)
            return Result.Fail("Cliente não encontrado.");

        condutor.Cliente = cliente;

        if (condutor.ClienteCondutor is true)
        {
            condutor.Nome = cliente.Nome;
            condutor.CPF = cliente.CPF;
            condutor.Telefone = cliente.Telefone;
            condutor.Email = cliente.Email;
        }

        _repositorioCondutor.Cadastrar(condutor);
        return Result.Ok(condutor);
    }
    public Result<Condutor> SelecionarId(int id)
    {
        var condutor = _repositorioCondutor.SelecionarPorId(id);

        if (condutor is null)
            return Result.Fail("Não foi encontrado condutor.");

        return Result.Ok(condutor);
    }
    public Result<List<Condutor>> SelecionarTodos()
    {
        var condutores = _repositorioCondutor.SelecionarTodos();

        if (condutores is null)
            return Result.Fail("Não foi encontrado condutores.");

        return Result.Ok(condutores);
    }
}
