using Microsoft.EntityFrameworkCore;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPessoas;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloFuncionario;

namespace LocadoraDeVeiculos.Infra.ModuloPessoas.ModuloFuncionarios;
public class RepositorioFuncionarioEmOrm : RepositorioBaseEmOrm<Funcionario>, IRepositorioFuncionario, ISelecionarIdPorEmpresa
{
    public RepositorioFuncionarioEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Funcionario> ObterRegistros()
    {
        return _dbContext.Funcionarios;
    }

    public override Funcionario? SelecionarPorId(int funcionarioId)
    {
        return _dbContext.Funcionarios
            .Include(u => u.Empresa)
            .FirstOrDefault(f => f.Id == funcionarioId);
    }

    public List<Funcionario> SelecionarTodos(Func<Funcionario, bool> predicate)
    {
        return _dbContext.Funcionarios
            .Include(u => u.Empresa)
            .Where(predicate)
            .ToList();
    }

    public Funcionario? SelecionarIdPorEmpresa(Func<Funcionario, bool> predicate)
    {
        return _dbContext.Funcionarios
            .Include(u => u.Empresa)
            .FirstOrDefault(predicate);
    }

    public List<Funcionario> Filtrar(Func<Funcionario, bool> predicate)
    {
        return _dbContext.Funcionarios
            .Include(c => c.Empresa)
            .Where(predicate)
            .ToList();
    }
}