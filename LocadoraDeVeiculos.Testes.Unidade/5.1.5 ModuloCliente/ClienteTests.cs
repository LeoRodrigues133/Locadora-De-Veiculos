using LocadoraDeVeiculos.Dominio;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloCliente;

[TestClass]
[TestCategory("Unidade")]
public class ClienteTests
{
        [TestMethod]
        public void Deve_Criar_Instancia_Valida()
        {
            var cliente = new Cliente
            (
                "123456789",
                "João Silva",
                "joao.silva@example.com",
                "(11) 98765-4321",
                "Rua A, 123",
                true,
                "12345678900",
                null
            );

            var erros = cliente.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_Nome()
        {
            var cliente = new Cliente
            (
                "123456789",
                "",
                "joao.silva@example.com",
                "(11) 98765-4321",
                "Rua A, 123",
                true,
                "12345678900",
                null
            );

            var erros = cliente.Validar();

            List<string> errosEsperados = new List<string>
            {
                "O nome é obrigatório."
            };

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_Email()
        {
            var cliente = new Cliente
            (
                "123456789",
                "João Silva",
                "",
                "(11) 98765-4321",
                "Rua A, 123",
                true,
                "12345678900",
                null
            );

            var erros = cliente.Validar();

            List<string> errosEsperados = new List<string>
            {
                "O email é obrigatório."
            };

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_Telefone()
        {
            var cliente = new Cliente
            (
                "123456789",
                "João Silva",
                "joao.silva@example.com",
                "",
                "Rua A, 123",
                true,
                "12345678900",
                null
            );

            var erros = cliente.Validar();

            List<string> errosEsperados = new List<string>
            {
                "O telefone é obrigatório."
            };

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_CPF()
        {
            var cliente = new Cliente
            (
                "123456789",
                "João Silva",
                "joao.silva@example.com",
                "(11) 98765-4321",
                "Rua A, 123",
                true,
                "",
                null
            );

            var erros = cliente.Validar();

            List<string> errosEsperados = new List<string>
            {
                "O CPF é obrigatório e deve conter 11 dígitos."
            };

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_CNPJ()
        {
            var cliente = new Cliente
            (
                "123456789",
                "João Silva",
                "joao.silva@example.com",
                "(11) 98765-4321",
                "Rua A, 123",
                false,
                null,
                ""
            );

            var erros = cliente.Validar();

            List<string> errosEsperados = new List<string>
            {
                "O CNPJ é obrigatório e deve conter 14 dígitos."
            };

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erros_Gerais()
        {
            var cliente = new Cliente
            (
                "123456789",
                "",
                "",
                "",
                "",
                true,
                "",
                null
            );

            var erros = cliente.Validar();

            List<string> errosEsperados = new List<string>
            {
                "O nome é obrigatório.",
                "O email é obrigatório.",
                "O telefone é obrigatório.",
                "O CPF é obrigatório e deve conter 11 dígitos.",
                "O endereço é obrigatório."
            };

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }

