using LocadoraDeVeiculos.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Compartilhado;

public abstract class RepositorioBaseEmOrm<Generico> where Generico : EntidadeBase
{
    protected readonly LocadoraDbContext _dbContext;

    protected RepositorioBaseEmOrm(LocadoraDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected abstract DbSet<Generico> ObterRegistros();

    public void Cadastrar(Generico entidade)
    {
        ObterRegistros().Add(entidade);

        _dbContext.SaveChanges();
    }

    public void Editar(Generico entidade)
    {
        ObterRegistros().Update(entidade);

        _dbContext.SaveChanges();
    }

    public void Excluir(Generico entidade)
    {
        ObterRegistros().Remove(entidade);

        _dbContext.SaveChanges();
    }

    public virtual Generico? SelecionarPorId(int id)
    {
        return ObterRegistros().FirstOrDefault(r => r.Id == id);
    }

    public virtual List<Generico> SelecionarTodos()
    {
        return ObterRegistros()
            .ToList();
    }
}
