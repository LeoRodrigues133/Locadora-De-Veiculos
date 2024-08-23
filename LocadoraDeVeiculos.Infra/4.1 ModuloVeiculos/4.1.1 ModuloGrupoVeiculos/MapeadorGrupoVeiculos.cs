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

    }
}
