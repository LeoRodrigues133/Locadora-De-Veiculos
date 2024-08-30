using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Infra.Compartilhado;
public class MapeadorGrupoVeiculos : IEntityTypeConfiguration<GrupoVeiculos>
{
    public void Configure(EntityTypeBuilder<GrupoVeiculos> builderGrupo)
    {
        builderGrupo.ToTable("TBGrupo");

        builderGrupo.Property(v => v.Id)
            .IsRequired()
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builderGrupo.Property(g => g.Nome)
            .IsRequired()
            .HasColumnType("varchar(25)");
        // Adiciona dados iniciais
        builderGrupo.HasData(DefaultDataGrupos());
    }

    private GrupoVeiculos[] DefaultDataGrupos()
    {
        return new[]
        {
                new GrupoVeiculos { Id = 1, Nome = "SUV" },
                new GrupoVeiculos { Id = 5, Nome = "Coupe" },
                new GrupoVeiculos { Id = 3, Nome = "Sedan" },
                new GrupoVeiculos { Id = 7, Nome = "Pickup" },
                new GrupoVeiculos { Id = 8, Nome = "Minivan" },
                new GrupoVeiculos { Id = 4, Nome = "Hatchback" },
                new GrupoVeiculos { Id = 9, Nome = "Esportivo" },
                new GrupoVeiculos { Id = 10, Nome = "Elétrico" },
                new GrupoVeiculos { Id = 2, Nome = "Utilitário" },
                new GrupoVeiculos { Id = 6, Nome = "Conversível" },
            };
    }
}
