using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio;

namespace LocadoraDeVeiculos.Infra.Compartilhado;

public class LocadoraDbContext : DbContext
{
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<GrupoVeiculos> GrupoVeiculos { get; set; }
    public DbSet<Plano> Planos { get; set; }

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
        modelBuilder.ApplyConfiguration(new MapeadorVeiculos());
        modelBuilder.ApplyConfiguration(new MapeadorGrupoVeiculos());
        modelBuilder.ApplyConfiguration(new MapeadorPlanos());

        base.OnModelCreating(modelBuilder);
    }
}