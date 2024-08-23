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

    public override List<Veiculo> SelecionarTodos()
    {

        return _dbContext.Veiculos.Include(v => v.GrupoVeiculos).ToList();
    }

    public override Veiculo SelecionarPorId(int id)
    {
        return _dbContext.Veiculos
            .Include(v => v.GrupoVeiculos)
            .FirstOrDefault(v => v.Id == id)!;
    }

    public List<Veiculo> Filtrar(Func<Veiculo, bool> predicate)
    {
        throw new NotImplementedException();
    }

}
