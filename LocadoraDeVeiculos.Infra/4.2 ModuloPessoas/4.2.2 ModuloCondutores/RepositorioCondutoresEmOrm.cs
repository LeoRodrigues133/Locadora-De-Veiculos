using LocadoraDeVeiculos.Dominio;
using Microsoft.EntityFrameworkCore;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloCondutores;

namespace LocadoraDeVeiculos.Infra.ModuloPessoas.ModuloCondutores;
public class RepositorioCondutoresEmOrm : RepositorioBaseEmOrm<Condutor>, IRepositorioCondutor
{
    public RepositorioCondutoresEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    public List<Condutor> Filtrar(Func<Condutor, bool> predicate)
    {
        return _dbContext.Condutores
            .Include(c=>c.Cliente)
            .Where(predicate)
            .ToList();
    }
    
    protected override DbSet<Condutor> ObterRegistros()
    {
        return _dbContext.Condutores;
    }
    public override Condutor? SelecionarPorId(int id)
    {
        return _dbContext.Condutores
                    .Include(c=>c.Cliente)
                    .FirstOrDefault(c => c.Id == id)!;
    }
    public override List<Condutor> SelecionarTodos()
    {
        return _dbContext.Condutores
            .Include(c => c.Cliente)
            .ToList();
    }
}
