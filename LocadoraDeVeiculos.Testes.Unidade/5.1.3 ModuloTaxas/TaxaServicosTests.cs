using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
using System.Drawing;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloTaxas;

[TestClass]
[TestCategory("Unidade")]
public class TaxaServicosTests
{
    [TestMethod]
    public void Deve_Criar_Instancia_Valida()
    {
        var Taxa = new TaxaServico("Seguro", 15.57m, true);

        var erros = Taxa.Validar();

        Assert.AreEqual(0, erros.Count);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erro()
    {
        var Taxa = new TaxaServico("", 0m, false);

        var erros = Taxa.Validar();

        List<string> errosEsperados = [
            "O nome da taxa é obrigatório.",
            "O valor da taxa deve ser maior que zero."
            ];

        Assert.AreEqual(2, erros.Count);
        CollectionAssert.AreEqual(errosEsperados,erros);
    }
}
