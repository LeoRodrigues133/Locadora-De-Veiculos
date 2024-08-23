using LocadoraDeVeiculos.Dominio;
using Microsoft.EntityFrameworkCore;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis;

namespace LocadoraDeVeiculos.Infra.ModuloAlugueis;
public class RepositorioPlanoEmOrm : RepositorioBaseEmOrm<Plano>, IRepositorioPlano
{
    public RepositorioPlanoEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    public List<Plano> Filtrar(Func<Plano, bool> predicate)
    {
        throw new NotImplementedException();
    }

    protected override DbSet<Plano> ObterRegistros()
    {
        return _dbContext.Planos;
    }

    public override Plano? SelecionarPorId(int id)
    {
        return _dbContext.Planos
            .Include(p => p.GrupoVeiculos)
            .FirstOrDefault(v => v.Id == id)!;
    }

    public override List<Plano> SelecionarTodos()
    {
        return _dbContext.Planos.Include(p => p.GrupoVeiculos).ToList();
    }
}
