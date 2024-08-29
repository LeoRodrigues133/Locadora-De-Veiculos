using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Infra.ModuloPessoas;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;

namespace LocadoraDeVeiculos.Infra.Compartilhado;

public class LocadoraDbContext : DbContext
{
    public DbSet<Plano> Planos { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Cliente> Clientes { get;  set; }
    public DbSet<GrupoVeiculos> GrupoVeiculos { get; set; }
    public DbSet<Condutor> Condutores { get; set; }
    public DbSet<TaxaServico> Taxas { get; set; }
    public DbSet<Aluguel> Alugueis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config
            .GetConnectionString("SqlServer");

        optionsBuilder.UseSqlServer(connectionString);

        optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MapeadorTaxas());
        modelBuilder.ApplyConfiguration(new MapeadorPlanos());
        modelBuilder.ApplyConfiguration(new MapeadorAlugueis());
        modelBuilder.ApplyConfiguration(new MapeadorVeiculos());
        modelBuilder.ApplyConfiguration(new MapeadorClientes());
        modelBuilder.ApplyConfiguration(new MapeadorCondutores());
        modelBuilder.ApplyConfiguration(new MapeadorGrupoVeiculos());

        base.OnModelCreating(modelBuilder);
    }
}