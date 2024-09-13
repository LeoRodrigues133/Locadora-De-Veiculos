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

    public Result<Condutor> Editar(Condutor condutorEditado)
    {
        var condutorSelecionado = _repositorioCondutor.SelecionarPorId(condutorEditado.Id);

        if (condutorSelecionado is null)
            return Result.Fail("O Condutor não foi encontrado.");

        var cliente = _repositorioCliente.SelecionarPorId(condutorSelecionado.ClienteId);

        if (cliente is null)
            return Result.Fail("Cliente não encontrado.");

        condutorSelecionado.Cliente = cliente;

        #region edit
        condutorSelecionado.ClienteId = condutorEditado.ClienteId;

        condutorSelecionado.ClienteCondutor = condutorEditado.ClienteCondutor;

        condutorSelecionado.CNH = condutorEditado.CNH;

        condutorSelecionado.ValidadeCNH = condutorEditado.ValidadeCNH;

        if (condutorSelecionado.ClienteCondutor == true)
        {
            condutorSelecionado.Nome = cliente.Nome;
            condutorSelecionado.CPF = cliente.CPF;
            condutorSelecionado.Email = cliente.Email;
            condutorSelecionado.Telefone = cliente.Telefone;
        }
        else
        {
            condutorSelecionado.CPF = condutorEditado.CPF;
            condutorSelecionado.Nome = condutorEditado.Nome;
            condutorSelecionado.Email = condutorEditado.Email;
            condutorSelecionado.Telefone = condutorEditado.Telefone;
        }
        #endregion

        _repositorioCondutor.Editar(condutorSelecionado);

        return Result.Ok(condutorSelecionado);
    }

    public Result<Condutor> Excluir(int id)
    {
        var condutor = _repositorioCondutor.SelecionarPorId(id);

        if (condutor is null)
            return Result.Fail("O Condutor não foi encontrado.");

        _repositorioCondutor.Excluir(condutor);

        return Result.Ok();
    }

    public Result<Condutor> SelecionarId(int id)
    {
        var condutor = _repositorioCondutor.SelecionarPorId(id);

        if (condutor is null)
            return Result.Fail("Não foi encontrado condutor.");

        return Result.Ok(condutor);
    }
    public Result<List<Condutor>> SelecionarTodos(int id)
    {
        var condutores = _repositorioCondutor.Filtrar(x => x.EmpresaId == id);

        if (condutores is null)
            return Result.Fail("Não foi encontrado condutores.");

        return Result.Ok(condutores);
    }
}
