using LocadoraDeVeiculos.Dominio;
using Microsoft.EntityFrameworkCore;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloAlugueis;

namespace LocadoraDeVeiculos.Infra.ModuloAlugueis;
public class RepositorioAluguelEmOrm : RepositorioBaseEmOrm<Aluguel>, IRepositorioAluguel
{
    public RepositorioAluguelEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    public List<Aluguel> Filtrar(Func<Aluguel, bool> predicate)
    {
        return _dbContext.Alugueis
            .Include(c => c.Condutor)
                .ThenInclude(c => c.Cliente)
            .Include(c => c.Veiculo)
            .Include(v => v.Grupo)
            .Include(c => c.Plano)
            .Include(c => c.Taxas)
            .Where(predicate)
            .ToList();
    }

    protected override DbSet<Aluguel> ObterRegistros()
    {
        return _dbContext.Alugueis;
    }

    public override Aluguel? SelecionarPorId(int id)
    {
        return _dbContext.Alugueis
            .Include(c => c.Condutor)
            .ThenInclude(c => c.Cliente)
            .Include(c => c.Veiculo)
            .Include(v => v.Grupo)
            .Include(c => c.Plano)
            .Include(c => c.Taxas)
            .FirstOrDefault(c => c.Id == id)!;
    }
    public override List<Aluguel> SelecionarTodos()
    {
        return _dbContext.Alugueis.Include(c => c.Condutor)
            .Include(c => c.Veiculo)
            .Include(v => v.Grupo)
            .Include(c => c.Plano)
            .Include(c => c.Taxas)
            .ToList();
    }
}
