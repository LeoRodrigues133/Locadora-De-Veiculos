using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Testes.Integracao.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Testes.Integracao.ModuloPlanos;
[TestClass]
[TestCategory("Integração")]
public class RepositorioPlanoCobrancaEmOrmTests : RepositorioEmOrmTestsBase
{

    [TestMethod]
    public void Deve_Inserir_PlanoCobranca()
    {
        var grupo = Builder<GrupoVeiculos>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var planoCobranca = Builder<Plano>
        .CreateNew()
            .With(p => p.Id = 0)
        .With(p => p.GrupoVeiculosId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Build();

        repositorioPlano.Cadastrar(planoCobranca);

        var planoCobrancaSelecionado = repositorioPlano.SelecionarPorId(planoCobranca.Id);

        Assert.IsNotNull(planoCobrancaSelecionado);
        Assert.AreEqual(planoCobranca, planoCobrancaSelecionado);
    }

    [TestMethod]
    public void Deve_Editar_PlanoCobranca()
    {
        var grupo = Builder<GrupoVeiculos>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var planoCobranca = Builder<Plano>
            .CreateNew()
            .With(p => p.Id = 0)
            .With(p => p.GrupoVeiculosId = grupo.Id)
        .With(g => g.EmpresaId = usuarioAutenticado.Id)
        .Persist();

        planoCobranca.ValorDiaria = 200.0m;

        repositorioPlano.Editar(planoCobranca);

        var planoCobrancaSelecionado = repositorioPlano.SelecionarPorId(planoCobranca.Id);

        Assert.IsNotNull(planoCobrancaSelecionado);
        Assert.AreEqual(planoCobranca, planoCobrancaSelecionado);
    }

    [TestMethod]
    public void Deve_Excluir_PlanoCobranca()
    {
        var grupo = Builder<GrupoVeiculos>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var planoCobranca = Builder<Plano>
        .CreateNew()
        .With(p => p.Id = 0)
        .With(p => p.GrupoVeiculosId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
        .Persist();

        repositorioPlano.Excluir(planoCobranca);

        var planoCobrancaSelecionado = repositorioPlano.SelecionarPorId(planoCobranca.Id);

        var planosCobranca = repositorioPlano.SelecionarTodos();

        Assert.IsNull(planoCobrancaSelecionado);
        Assert.AreEqual(0, planosCobranca.Count);
    }
}