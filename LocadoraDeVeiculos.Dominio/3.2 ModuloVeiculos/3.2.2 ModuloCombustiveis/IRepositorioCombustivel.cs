namespace LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;
public interface IRepositorioCombustivel
{
    void Gravar(Combustivel entidade);
    void Editar(Combustivel entidadeAtualizada);
    Combustivel? SelecionarPorId(int idSelecionado);

}
