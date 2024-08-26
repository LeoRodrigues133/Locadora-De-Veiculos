using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloClientes;
using LocadoraDeVeiculos.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.ModuloPessoas.ModuloClientes;
public class RepositorioClienteEmOrm : RepositorioBaseEmOrm<Cliente>, IRepositorioCliente
{
    public RepositorioClienteEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    public List<Cliente> Filtrar(Func<Cliente, bool> predicate)
    {
        throw new NotImplementedException();
    }

    protected override DbSet<Cliente> ObterRegistros()
    {
        return _dbContext.Clientes;
    }
    public override Cliente? SelecionarPorId(int id)
    {
        return _dbContext.Clientes.FirstOrDefault(c => c.Id == id)!;
    }

    public override List<Cliente> SelecionarTodos()
    {
        return _dbContext.Clientes.ToList();
    }
}
