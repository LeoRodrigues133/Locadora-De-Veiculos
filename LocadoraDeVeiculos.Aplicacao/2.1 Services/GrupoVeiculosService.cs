using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Aplicacao.Services;
public class GrupoVeiculosService
{
    readonly IRepositorioGrupoVeiculos _repositorioGrupo;

    public GrupoVeiculosService(IRepositorioGrupoVeiculos repositorioGrupo)
    {
        _repositorioGrupo = repositorioGrupo;
    }

    public Result<GrupoVeiculos> Cadastrar(GrupoVeiculos grupo)
    {

        #region Erros
        if (string.IsNullOrEmpty(grupo.Nome) || grupo.Nome.Length < 3)
            Result.Fail("Grupo inválido.");
        #endregion

        _repositorioGrupo.Cadastrar(grupo);

        return Result.Ok(grupo);
    }

    public Result<GrupoVeiculos> Editar(GrupoVeiculos grupoEditado)
    {
        var grupoSelecionado = _repositorioGrupo.SelecionarPorId(grupoEditado.Id);

        if (grupoSelecionado is null)
            Result.Fail("O grupo não foi encontrado");

        #region Erros
        if (string.IsNullOrEmpty(grupoSelecionado.Nome) || grupoSelecionado.Nome.Length < 3)
            Result.Fail("Grupo inválido.");
        #endregion

        #region Edit
        grupoSelecionado.Nome = grupoEditado.Nome;
        #endregion

        _repositorioGrupo.Editar(grupoSelecionado);

        return Result.Ok(grupoSelecionado);
    }

    public Result<GrupoVeiculos> Excluir(int id)
    {
        var grupo = _repositorioGrupo.SelecionarPorId(id);

        if (grupo is null)
            Result.Fail("O grupo não foi encontrado");

        _repositorioGrupo.Excluir(grupo);

        return Result.Ok();
    }

    public Result<GrupoVeiculos> SelecionarId(int id)
    {
        var grupo = _repositorioGrupo.SelecionarPorId(id);

        return Result.Ok(grupo);
    }

    public Result<List<GrupoVeiculos>> SelecionarTodos(int empresaId)
    {
        var grupo = _repositorioGrupo.Filtrar(x => x.EmpresaId == empresaId);

        return Result.Ok(grupo);
    }

}
