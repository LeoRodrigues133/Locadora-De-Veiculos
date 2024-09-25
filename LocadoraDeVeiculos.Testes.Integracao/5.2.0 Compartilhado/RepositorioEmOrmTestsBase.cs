using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloAlugueis;
using LocadoraDeVeiculos.Infra.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloUsuario;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Infra.ModuloAlugueis.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
using LocadoraDeVeiculos.Infra.ModuloPessoas.ModuloClientes;
using LocadoraDeVeiculos.Infra.ModuloPessoas.ModuloCondutores;
using LocadoraDeVeiculos.Infra.ModuloVeiculos.ModuloCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Testes.Integracao.Compartilhado;
public abstract class RepositorioEmOrmTestsBase
{
    protected LocadoraDbContext dbContext;

    protected RepositorioTaxasEmOrm repositorioTaxa;
    protected RepositorioPlanoEmOrm repositorioPlano;
    protected RepositorioClienteEmOrm repositorioCliente;
    protected RepositorioAluguelEmOrm repositorioLocacao;
    protected RepositorioVeiculosEmOrm repositorioVeiculo;
    protected RepositorioGrupoVeiculosOrm repositorioGrupo;
    protected RepositorioCondutoresEmOrm repositorioCondutor;
    protected RepositorioCombustivelEmOrm repositorioCombustivel;

    protected Usuario usuarioAutenticado;

    [TestInitialize]
    public void Inicializar()
    {
        dbContext = new LocadoraDbContext();

        dbContext.Taxas.RemoveRange(dbContext.Taxas);
        dbContext.Planos.RemoveRange(dbContext.Planos);
        dbContext.Clientes.RemoveRange(dbContext.Clientes);
        dbContext.Veiculos.RemoveRange(dbContext.Veiculos);
        dbContext.Usuarios.RemoveRange(dbContext.Usuarios);
        dbContext.Alugueis.RemoveRange(dbContext.Alugueis);
        dbContext.Condutores.RemoveRange(dbContext.Condutores);
        dbContext.Combustiveis.RemoveRange(dbContext.Combustiveis);
        dbContext.GrupoVeiculos.RemoveRange(dbContext.GrupoVeiculos);

        usuarioAutenticado = new Usuario()
        {
            UserName = "Empresa Teste",
            Email = "empresa_teste@gmail.com"
        };

        dbContext.Usuarios.Add(usuarioAutenticado);

        dbContext.SaveChanges();

        repositorioTaxa = new RepositorioTaxasEmOrm(dbContext);
        repositorioPlano = new RepositorioPlanoEmOrm(dbContext);
        repositorioCliente = new RepositorioClienteEmOrm(dbContext);
        repositorioLocacao = new RepositorioAluguelEmOrm(dbContext);
        repositorioVeiculo = new RepositorioVeiculosEmOrm(dbContext);
        repositorioGrupo = new RepositorioGrupoVeiculosOrm(dbContext);
        repositorioCondutor = new RepositorioCondutoresEmOrm(dbContext);
        repositorioCombustivel = new RepositorioCombustivelEmOrm(dbContext);

        BuilderSetup.SetCreatePersistenceMethod<Plano>(repositorioPlano.Cadastrar);
        BuilderSetup.SetCreatePersistenceMethod<Aluguel>(repositorioLocacao.Cadastrar);
        BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorioCliente.Cadastrar);
        BuilderSetup.SetCreatePersistenceMethod<Veiculo>(repositorioVeiculo.Cadastrar);
        BuilderSetup.SetCreatePersistenceMethod<TaxaServico>(repositorioTaxa.Cadastrar);
        BuilderSetup.SetCreatePersistenceMethod<Condutor>(repositorioCondutor.Cadastrar);
        BuilderSetup.SetCreatePersistenceMethod<GrupoVeiculos>(repositorioGrupo.Cadastrar);
        BuilderSetup.SetCreatePersistenceMethod<Combustivel>(repositorioCombustivel.Gravar);
    }
}