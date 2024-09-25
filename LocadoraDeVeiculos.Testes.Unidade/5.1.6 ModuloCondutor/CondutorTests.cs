using LocadoraDeVeiculos.Dominio;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloCondutor;

[TestClass]
[TestCategory("Unidade")]
public class CondutorTests
{
        [TestMethod]
        public void Deve_Criar_Instancia_Valida()
        {
            var condutor = new Condutor
            (
                "12345678900",
                DateTime.Now.AddYears(1), // Validade CNH no futuro
                true,
                1,
                "João Silva",
                "joao.silva@example.com",
                "(11) 98765-4321",
                "12345678900"
            );

            var erros = condutor.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_Nome()
        {
            var condutor = new Condutor
            (
                "12345678900",
                DateTime.Now.AddYears(1), // Validade CNH no futuro
                true,
                1,
                "",
                "joao.silva@example.com",
                "(11) 98765-4321",
                "12345678900"
            );

            var erros = condutor.Validar();

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
            var condutor = new Condutor
            (
                "12345678900",
                DateTime.Now.AddYears(1), // Validade CNH no futuro
                true,
                1,
                "João Silva",
                "",
                "(11) 98765-4321",
                "12345678900"
            );

            var erros = condutor.Validar();

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
            var condutor = new Condutor
            (
                "12345678900",
                DateTime.Now.AddYears(1), // Validade CNH no futuro
                true,
                1,
                "João Silva",
                "joao.silva@example.com",
                "",
                "12345678900"
            );

            var erros = condutor.Validar();

            List<string> errosEsperados = new List<string>
            {
                "O telefone é obrigatório."
            };

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_CNH()
        {
            var condutor = new Condutor
            (
                "",
                DateTime.Now.AddYears(1), // Validade CNH no futuro
                true,
                1,
                "João Silva",
                "joao.silva@example.com",
                "(11) 98765-4321",
                "12345678900"
            );

            var erros = condutor.Validar();

            List<string> errosEsperados = new List<string>
            {
                "A CNH é obrigatória."
            };

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_ValidadeCNH()
        {
            var condutor = new Condutor
            (
                "12345678900",
                DateTime.Now.AddDays(-1), // Validade CNH no passado
                true,
                1,
                "João Silva",
                "joao.silva@example.com",
                "(11) 98765-4321",
                "12345678900"
            );

            var erros = condutor.Validar();

            List<string> errosEsperados = new List<string>
            {
                "A validade da CNH deve ser uma data futura."
            };

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_CPF()
        {
            var condutor = new Condutor
            (
                "12345678900",
                DateTime.Now.AddYears(1), // Validade CNH no futuro
                true,
                1,
                "João Silva",
                "joao.silva@example.com",
                "(11) 98765-4321",
                ""
            );

            var erros = condutor.Validar();

            List<string> errosEsperados = new List<string>
            {
                "O CPF é obrigatório e deve conter 11 dígitos."
            };

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erros_Gerais()
        {
            var condutor = new Condutor
            (
                "",
                DateTime.Now.AddDays(-1), // Validade CNH no passado
                true,
                1,
                "",
                "",
                "",
                ""
            );

            var erros = condutor.Validar();

            List<string> errosEsperados = new List<string>
            {
                "O nome é obrigatório.",
                "O email é obrigatório.",
                "O telefone é obrigatório.",
                "A CNH é obrigatória.",
                "A validade da CNH deve ser uma data futura.",
                "O CPF é obrigatório e deve conter 11 dígitos."
            };

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }
