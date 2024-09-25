//using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
//using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;

//namespace LocadoraDeVeiculos.Testes.Unidade.ModuloVeiculos;

//[TestClass]
//[TestCategory("Unidade")]
//public class VeiculosTests
//{
//    [TestMethod]
//    public void Deve_Criar_Instancia_Valida()
//    {
//        var veiculo = new Veiculo
//       (
//           Cor.Prata,
//           Marca.Hyundai,
//           EnumCombustivel.GNV,
//           1,
//           2000,
//           false,
//           "PLA4C45",
//           "AnyCarro",
//           0,
//           80
//       );

//        var erros = veiculo.Validar();

//        Assert.AreEqual(0, erros.Count);
    
//}

//    [TestMethod]
//    public void Deve_Alocar_Quilometragem()
//    {
//        var veiculo = new Veiculo
//        (
//            Cor.Preto,
//            Marca.Ford,
//            EnumCombustivel.Gasolina,
//            1,
//            2022,
//            false,
//            "PLA4C56",
//            "Fusion",
//            100000,
//            60
//        );

//        veiculo.AlocarQuilometragem(500);

//        Assert.AreEqual(100500, veiculo.Quilometragem);
//    }

//    [TestMethod]
//    public void Deve_Criar_Instancia_Com_Erro()
//    {
//        var veiculos = new Veiculo
//            (
//                0, 
//                0, 
//                0, 
//                0,
//                0, 
//                false,
//                "", 
//                "", 
//                -1, 
//                0 
//            );

//        var erros = veiculos.Validar();

//        Assert.AreEqual(6, erros.Count);
//    }

//    [TestMethod]
//    public void Deve_Alocar()
//    {
//        var veiculo = new Veiculo(0, 0, 0, 0, 0, false, "ABC1D23","AnyCar",0,100);

//        veiculo.Alocar();

//        Assert.AreEqual(veiculo.Alugado, true);
//    }

//    [TestMethod]
//    public void Deve_Desalocar()
//    {
//        var veiculo = new Veiculo(0, 0, 0, 0, 0, true, "ABC1D23","AnyCar",0,100);

//        veiculo.Desalocar();

//        Assert.AreEqual(veiculo.Alugado, false);
//    }

//    [TestMethod]
//    public void Deve_Calcular_Litros_Para_Abastecimento()
//    {
//        var veiculo = new Veiculo
//        (
//            Cor.Branco,
//            Marca.Toyota,
//            EnumCombustivel.Etanol,
//            1,
//            2021,
//            false,
//            "PLA1234",
//            "Corolla",
//            50000,
//            50
//        );

//        var litros = veiculo.CalcularLitrosParaAbastecimento(EnumMarcadorCombustivel.MeioTanque);
//        Assert.AreEqual(25, litros);
//    }
//}
