using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloAluguel;

[TestClass]
[TestCategory("Unidade")]
public class AluguelTests
{
    [TestMethod]
    public void Deve_Criar_Instancia_Valida()
    {
        var aluguel = new Aluguel
        (
            100,
            1,
            1,
            1,
            1,
            1,
            null,
            1,
            200.00m,
            DateTime.Now,
            DateTime.Now.AddDays(5),
            EnumMarcadorCombustivel.Completo
        );

        var erros = aluguel.Validar();

        Assert.AreEqual(0, erros.Count);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erro_Entrada_Negativa()
    {
        var aluguel = new Aluguel
        (
            -50,
            1,
            1,
            1,
            1,
            1,
            null,
            1,
            200.00m,
            DateTime.Now,
            DateTime.Now.AddDays(5),
            EnumMarcadorCombustivel.Completo
        );

        var erros = aluguel.Validar();

        List<string> errosEsperados = new List<string>
            {
                "A entrada não pode ser negativa."
            };

        Assert.AreEqual(errosEsperados.Count, erros.Count);
        CollectionAssert.AreEqual(errosEsperados, erros);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erro_DataDevolucaoPrevista()
    {
        var aluguel = new Aluguel
        (
            100,
            1,
            1,
            1,
            1,
            1,
            null,
            1,
            200.00m,
            DateTime.Now,
            DateTime.Now.AddDays(-5),
            EnumMarcadorCombustivel.Completo
        );

        var erros = aluguel.Validar();

        List<string> errosEsperados = new List<string>
            {
                "A data de devolução prevista deve ser uma data futura em relação à data de locação."
            };

        Assert.AreEqual(errosEsperados.Count, erros.Count);
        CollectionAssert.AreEqual(errosEsperados, erros);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erro_ClienteInvalido()
    {
        var aluguel = new Aluguel
        (
            100,
            1,
            1,
            0,
            1,
            1,
            null,
            1,
            200.00m,
            DateTime.Now,
            DateTime.Now.AddDays(5),
            EnumMarcadorCombustivel.Completo
        );

        var erros = aluguel.Validar();

        List<string> errosEsperados = new List<string>
            {
                "O cliente é obrigatório."
            };

        Assert.AreEqual(errosEsperados.Count, erros.Count);
        CollectionAssert.AreEqual(errosEsperados, erros);
    }

}
