using Microsoft.EntityFrameworkCore;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Infra.Compartilhado;
public class RepositorioGrupoVeiculosOrm : RepositorioBaseEmOrm<GrupoVeiculos>, IRepositorioGrupoVeiculos
{
    public RepositorioGrupoVeiculosOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    public List<GrupoVeiculos> Filtrar(Func<GrupoVeiculos, bool> predicate)
    {
        return _dbContext.GrupoVeiculos
            .Where(predicate)
            .ToList();
    }

    protected override DbSet<GrupoVeiculos> ObterRegistros()
    {
        return _dbContext.GrupoVeiculos;
    }
}
