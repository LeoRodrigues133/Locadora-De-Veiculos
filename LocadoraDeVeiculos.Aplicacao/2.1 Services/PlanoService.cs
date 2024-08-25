using FluentResults;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Aplicacao.Services;
public class PlanoService
{
    readonly IRepositorioPlano _repositorioPlano;
    readonly IRepositorioGrupoVeiculos _repositorioGrupo;

    public PlanoService(IRepositorioPlano repositorioPlano, IRepositorioGrupoVeiculos repositorioGrupo)
    {
        _repositorioPlano = repositorioPlano;
        _repositorioGrupo = repositorioGrupo;
    }

    public Result<Plano> Cadastrar(Plano plano)
    {
        var id = plano.GrupoVeiculosId;

        var grupo = _repositorioGrupo.SelecionarPorId(id);

        plano.GrupoVeiculos = grupo;

        _repositorioPlano.Cadastrar(plano);

        return Result.Ok(plano);
    }

    public Result<Plano> Editar(Plano planoEditado)
    {
        var planoSelecionado = _repositorioPlano.SelecionarPorId(planoEditado.Id);

        if(planoSelecionado is null)
            return Result.Fail("O plano não foi encontrado!");
        #region Edit
        planoSelecionado.PrecoKM = planoEditado.PrecoKM;
        planoSelecionado.ValorDiaria= planoEditado.ValorDiaria;
        planoSelecionado.ValorExtrapolado= planoEditado.ValorExtrapolado;
        planoSelecionado.KmDisponivel= planoEditado.KmDisponivel;
        planoSelecionado.GrupoVeiculosId = planoEditado.GrupoVeiculosId;
        #endregion

        _repositorioPlano.Editar(planoSelecionado);

        return Result.Ok(planoSelecionado);
    }

    public Result<Plano> SelecionarId(int id)
    {
        var plano = _repositorioPlano.SelecionarPorId(id);

        if(plano is null)
            return Result.Fail("O plano não foi encontrado!");

        return Result.Ok(plano);
    }

    public Result<List<Plano>> SelecionarTodos()
    {
        var planos = _repositorioPlano.SelecionarTodos();

        return Result.Ok(planos);
    }
}
