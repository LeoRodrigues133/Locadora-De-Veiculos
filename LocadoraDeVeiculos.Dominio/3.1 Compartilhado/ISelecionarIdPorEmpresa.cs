namespace LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloFuncionario;
public interface ISelecionarIdPorEmpresa
{
    Funcionario? SelecionarIdPorEmpresa(Func<Funcionario, bool> predicate);
}
