using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;

namespace LocadoraDeVeiculos.Infra.ModuloVeiculos.ModuloCombustivel;
public class RepositorioCombustivelEmOrm : IRepositorioCombustivel
{
    readonly LocadoraDbContext _dbContext;
    public RepositorioCombustivelEmOrm(LocadoraDbContext dbContext) 
    {
        _dbContext = dbContext;
    }

    public void Gravar(Combustivel entidade)
    {
        _dbContext.Combustiveis.Add(entidade);

        _dbContext.SaveChanges();
    }

    public Combustivel? SelecionarIdPorEmpresa(int idEmpresa)
    {
        return _dbContext.Combustiveis
    .OrderByDescending(c => c.Id)
    .FirstOrDefault(c => c.EmpresaId == idEmpresa);
    }
}

