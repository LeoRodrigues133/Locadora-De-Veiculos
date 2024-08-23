
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

    public Result<List<Plano>> SelecionarTodos()
    {
        var planos = _repositorioPlano.SelecionarTodos();

        return Result.Ok(planos);
    }
}
