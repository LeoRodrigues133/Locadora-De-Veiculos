using LocadoraDeVeiculos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Compartilhado;
public class MapeadorPlanos : IEntityTypeConfiguration<Plano>
{
    public void Configure(EntityTypeBuilder<Plano> builderPlano)
    {
        builderPlano.ToTable("TBPlano");

        builderPlano.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builderPlano.Property(p => p.TipoPlano)
            .IsRequired()
            .HasColumnType("int");

        builderPlano.Property(p => p.PrecoKM)
            .HasColumnType("decimal")
            .IsRequired(false);

        builderPlano.Property(p => p.ValorDiaria)
            .HasColumnType("decimal")
            .IsRequired(false);


        builderPlano.Property(p => p.ValorExtrapolado)
            .HasColumnType("decimal")
            .IsRequired(false);

        builderPlano.Property(p => p.KmDisponivel)
            .HasColumnType("int")
            .IsRequired(false);

        builderPlano.Property(p => p.GrupoVeiculosId)
            .IsRequired()
            .HasColumnType("int");

        builderPlano.HasOne(p => p.GrupoVeiculos)
            .WithMany()
            .IsRequired()
            .HasForeignKey(p => p.GrupoVeiculosId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}