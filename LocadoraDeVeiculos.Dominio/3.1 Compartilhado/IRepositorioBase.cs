namespace LocadoraDeVeiculos.Dominio.Compartilhado;

public interface IRepositorioBase<Generico> where Generico : EntidadeBase
{
    void Cadastrar(Generico entidade);
    void Editar(Generico entidadeAtualizada);
    void Excluir(Generico entidadeParaExcluir);
    Generico? SelecionarPorId(int idSelecionado);
    List<Generico> SelecionarTodos();
    List<Generico> Filtrar(Func<Generico, bool> predicate);
    
}
