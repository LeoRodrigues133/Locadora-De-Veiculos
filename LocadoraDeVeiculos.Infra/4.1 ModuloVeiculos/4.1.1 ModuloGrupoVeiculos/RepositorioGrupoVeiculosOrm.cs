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
        throw new NotImplementedException();
    }

    protected override DbSet<GrupoVeiculos> ObterRegistros()
    {
        return _dbContext.GrupoVeiculos;
    }
}
