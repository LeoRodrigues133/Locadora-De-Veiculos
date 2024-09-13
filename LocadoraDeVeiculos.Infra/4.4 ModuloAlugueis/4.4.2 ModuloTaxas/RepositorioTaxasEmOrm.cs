using Microsoft.EntityFrameworkCore;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;

namespace LocadoraDeVeiculos.Infra.ModuloAlugueis.ModuloTaxas;
public class RepositorioTaxasEmOrm : RepositorioBaseEmOrm<TaxaServico>, IRepositorioTaxaEServicos
{
    public RepositorioTaxasEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    public List<TaxaServico> Filtrar(Func<TaxaServico, bool> predicate)
    {
        return _dbContext.Taxas
            .Where(predicate)
            .ToList();
    }

    protected override DbSet<TaxaServico> ObterRegistros()
    {
        return _dbContext.Taxas;
    }
    public override List<TaxaServico> SelecionarTodos()
    {
        return _dbContext.Taxas.ToList();
    }
}
