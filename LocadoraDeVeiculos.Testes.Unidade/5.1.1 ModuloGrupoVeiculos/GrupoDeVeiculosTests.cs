using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloGrupoVeiculos;

[TestClass]
[TestCategory("Unidade")]

public class GrupoDeVeiculosTests
{


    [TestMethod]
    public void Deve_Criar_Instancia_Valida()
    {
        var grupo = new GrupoVeiculos("SUV");

        var erros = grupo.Validar();

        Assert.AreEqual(0, erros.Count);
    }

    [TestMethod]
    public void Deve_Conter_Tamanho_Minimo()
    {
        var grupo = new GrupoVeiculos("AA");

        var erros = grupo.Validar();

        Assert.AreEqual(1, erros.Count);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erro()
    {
        var grupo = new GrupoVeiculos("");

        var erros = grupo.Validar();

        List<string> errosEsperados = [
            "O grupo deve conter um nome.",
            "O grupo deve conter ao menos tres caracteres."
        ];

        Assert.AreEqual(2, erros.Count);
        CollectionAssert.AreEqual(errosEsperados, erros);
    }
}
