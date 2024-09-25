using LocadoraDeVeiculos.Dominio;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloPlanos;

[TestClass]
[TestCategory("Unidade")]
public class PlanoTests
{
    [TestMethod]
    public void Deve_Criar_instancia_valida()
    {
        List<string> erros = new();

        var Planos = new List<Plano>();

        var planoDiario = new Plano(TipoPlano.Diario, 100, 12.5m, 0, 0, 1);

        var planoControlado = new Plano(TipoPlano.Controlado, 100, 0, 12.5m, 120, 1);

        var planoLivre = new Plano(TipoPlano.Livre, 350, 0, 0, 0, 1);

        Planos.Add(planoLivre);
        Planos.Add(planoDiario);
        Planos.Add(planoControlado);

        foreach (var plano in Planos)
        {
            erros = plano.Validar();

            Assert.AreEqual(0, erros.Count);
        }

    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erros_Livre()
    {
        var planoLivre = new Plano(TipoPlano.Livre, 0, 0, 0, 0, -1);

        List<string> errosPlanoLivre = planoLivre.Validar();

        List<string> errosEsperadosPlanoLivre = [
            "O valor da diária deve ser maior que zero.",
            "O grupo de veículos é obrigatório."
            ];

        Assert.AreEqual(2, errosPlanoLivre.Count);

        CollectionAssert.AreEqual(errosEsperadosPlanoLivre, errosPlanoLivre);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erros_Diario()
    {
        var planoDiario = new Plano(TipoPlano.Diario, 0, 0, 0, 0, -1);

        List<string> errosPlanoDiario = planoDiario.Validar();

        List<string> errosEsperadosPlanoDiario = [
            "O valor da diária deve ser maior que zero.",
            "O preço por KM deve ser maior que zero.",
            "O grupo de veículos é obrigatório."
            ];

        Assert.AreEqual(3, errosPlanoDiario.Count);
        CollectionAssert.AreEqual(errosEsperadosPlanoDiario, errosPlanoDiario);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erros_Controlado()
    {
        var planoControlado = new Plano(TipoPlano.Controlado, 0, 0, 0, 0, -1);

        List<string> errosPlanoControlado = planoControlado.Validar();

        List<string> errosEsperadosPlanoControlado = [
            "O valor da diária deve ser maior que zero.",
            "O valor extrapolado deve ser maior que zero.",
            "A quantidade de KM disponível deve ser maior que zero.",
            "O grupo de veículos é obrigatório."
            ];

        Assert.AreEqual(4, errosPlanoControlado.Count);
        CollectionAssert.AreEqual(errosEsperadosPlanoControlado, errosPlanoControlado);
    }

}
