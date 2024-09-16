namespace LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;
public interface IRepositorioCombustivel
{
    void Gravar(Combustivel entidade);
    Combustivel? SelecionarIdPorEmpresa(int idEmpresa);

}
