using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.ModuloVeiculos;

public class RepositorioVeiculosEmOrm : RepositorioBaseEmOrm<Veiculo>, IRepositorioVeiculo
{
    public RepositorioVeiculosEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Veiculo> ObterRegistros()
    {
        return _dbContext.Veiculos;
    }

    public List<Veiculo> Filtrar(Func<Veiculo, bool> predicate)
    {
        throw new NotImplementedException();
    }

}
