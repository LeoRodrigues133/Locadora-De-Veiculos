using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Testes.Integracao.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;

namespace LocadoraDeVeiculos.Testes.Integracao.ModuloAluguel;

[TestClass]
[TestCategory("Integração")]
public class RepositorioLocacaoEmOrmTests : RepositorioEmOrmTestsBase
{
    [TestMethod]
    public void Deve_Inserir_Locacao()
    {
        // Arrange
        var grupo = Builder<GrupoVeiculos>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var veiculo = Builder<Veiculo>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoVeiculosId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var cliente = Builder<Cliente>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var condutor = Builder<Condutor>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(c => c.ClienteId = cliente.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var Combustivel = Builder<Combustivel>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var plano = Builder<Plano>
            .CreateNew()
            .With (c => c.Id = 0)
            .With(c => c.GrupoVeiculosId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var aluguel = Builder<Aluguel>
            .CreateNew()
            .With(l => l.Id = 0)
            .With(l => l.VeiculoId = veiculo.Id)
            .With(l => l.GrupoId = grupo.Id)
            .With(l => l.CondutorId = condutor.Id)
            .With(l => l.ClienteId = cliente.Id)
            .With(l => l.PlanoId = plano.Id)
            .With(l => l.CombustivelId = Combustivel.Id)
            .With(l => l.DataLocacao = DateTime.Now)
            .With(l => l.DateDevolucaoPrevista = DateTime.Now.AddDays(3))
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Build();

        // Act
        repositorioLocacao.Cadastrar(aluguel);

        // Assert
        var locacaoSelecionada = repositorioLocacao.SelecionarPorId(aluguel.Id);

        Assert.IsNotNull(locacaoSelecionada);
        Assert.AreEqual(aluguel, locacaoSelecionada);
    }

    [TestMethod]
    public void Deve_Editar_Locacao()
    {
        // Arrange
        var grupo = Builder<GrupoVeiculos>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var veiculo = Builder<Veiculo>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoVeiculosId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var cliente = Builder<Cliente>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var condutor = Builder<Condutor>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(c => c.ClienteId = cliente.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var Combustivel = Builder<Combustivel>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var plano = Builder<Plano>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(c => c.GrupoVeiculosId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var aluguel = Builder<Aluguel>
            .CreateNew()
            .With(l => l.Id = 0)
            .With(l => l.VeiculoId = veiculo.Id)
            .With(l => l.GrupoId = grupo.Id)
            .With(l => l.CondutorId = condutor.Id)
            .With(l => l.ClienteId = cliente.Id)
            .With(l => l.PlanoId = plano.Id)
            .With(l => l.CombustivelId = Combustivel.Id)
            .With(l => l.DataLocacao = DateTime.Now)
            .With(l => l.DateDevolucaoPrevista = DateTime.Now.AddDays(3))
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Build();

        aluguel.DateDevolucaoPrevista = aluguel.DateDevolucaoPrevista?.AddDays(2);

        // Act
        repositorioLocacao.Editar(aluguel);

        // Assert
        var locacaoSelecionada = repositorioLocacao.SelecionarPorId(aluguel.Id);

        Assert.IsNotNull(locacaoSelecionada);
        Assert.AreEqual(aluguel, locacaoSelecionada);
    }

    [TestMethod]
    public void Deve_Excluir_Locacao()
    {
        // Arrange
        var grupo = Builder<GrupoVeiculos>
            .CreateNew()
            .With(g => g.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var veiculo = Builder<Veiculo>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoVeiculosId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var cliente = Builder<Cliente>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var condutor = Builder<Condutor>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(c => c.ClienteId = cliente.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var Combustivel = Builder<Combustivel>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var plano = Builder<Plano>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(c => c.GrupoVeiculosId = grupo.Id)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        var aluguel = Builder<Aluguel>
            .CreateNew()
            .With(l => l.Id = 0)
            .With(l => l.VeiculoId = veiculo.Id)
            .With(l => l.GrupoId = grupo.Id)
            .With(l => l.CondutorId = condutor.Id)
            .With(l => l.ClienteId = cliente.Id)
            .With(l => l.PlanoId = plano.Id)
            .With(l => l.CombustivelId = Combustivel.Id)
            .With(l => l.DataLocacao = DateTime.Now)
            .With(l => l.DateDevolucaoPrevista = DateTime.Now.AddDays(3))
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        // Act
        repositorioLocacao.Excluir(aluguel);

        // Assert
        var locacaoSelecionada = repositorioLocacao.SelecionarPorId(aluguel.Id);
        var locacoes = repositorioLocacao.SelecionarTodos();

        Assert.IsNull(locacaoSelecionada);
        Assert.AreEqual(0, locacoes.Count);
    }
}