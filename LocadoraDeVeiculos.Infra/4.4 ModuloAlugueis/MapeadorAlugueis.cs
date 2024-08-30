using LocadoraDeVeiculos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Compartilhado;
internal class MapeadorAlugueis : IEntityTypeConfiguration<Aluguel>
{
    public void Configure(EntityTypeBuilder<Aluguel> builderAluguel)
    {
        builderAluguel.ToTable("TBAluguel");

        builderAluguel.Property(a => a.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builderAluguel.Property(a => a.Entrada)
            .IsRequired()
            .HasColumnType("int");

        builderAluguel.Property(c=>c.ValorFinal)
            .IsRequired(false)
            .HasColumnType("decimal");

        builderAluguel.Property(c => c.GrupoId).HasColumnType("int").IsRequired();
        builderAluguel.Property(c => c.PlanoId).HasColumnType("int").IsRequired();
        builderAluguel.Property(c => c.VeiculoId).HasColumnType("int").IsRequired();
        builderAluguel.Property(c => c.CondutorId).HasColumnType("int").IsRequired();
        builderAluguel.Property(c => c.ClienteId).HasColumnType("int").IsRequired();

        builderAluguel.HasOne(a => a.Veiculo)
            .WithMany()
            .HasForeignKey(a => a.VeiculoId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builderAluguel.HasOne(a => a.Cliente)
            .WithMany()
            .HasForeignKey(a => a.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        builderAluguel.HasOne(a => a.Condutor)
            .WithMany()
            .HasForeignKey(a => a.CondutorId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builderAluguel.HasOne(c => c.Grupo)
            .WithMany()
            .HasForeignKey(c => c.GrupoId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builderAluguel.HasOne(c => c.Plano)
            .WithMany()
            .HasForeignKey(c => c.PlanoId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();


        builderAluguel.Property(a => a.DataLocacao)
            .IsRequired()
            .HasColumnType("datetime");

        builderAluguel.Property(a => a.DateDevolucaoPrevista)
            .IsRequired(false)
            .HasColumnType("datetime");

        builderAluguel.HasMany(c => c.Taxas)
            .WithMany(t => t.Alugueis)
            .UsingEntity(x => x.ToTable("TBAluguelTaxa"));
    }
}