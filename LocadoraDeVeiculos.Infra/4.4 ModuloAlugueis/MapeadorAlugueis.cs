using LocadoraDeVeiculos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Compartilhado;
public class MapeadorAlugueis : IEntityTypeConfiguration<Aluguel>
{
    public void Configure(EntityTypeBuilder<Aluguel> builderAluguel)
    {
        builderAluguel.ToTable("TBAluguel");

        builderAluguel.Property(x => x.EmpresaId)
            .IsRequired()
            .HasColumnType("int")
            .HasColumnName("Empresa_Id");

        builderAluguel.HasOne(x => x.Empresa)
            .WithMany()
            .HasForeignKey(x => x.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);


        builderAluguel.Property(a => a.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builderAluguel.Property(a => a.Entrada)
            .IsRequired()
            .HasColumnType("int");

        builderAluguel.Property(c=>c.ValorFinal)
            .IsRequired(false)
            .HasColumnType("decimal");

        builderAluguel.Property(c => c.KmFinal)
            .IsRequired(false)
            .HasColumnType("int");

        builderAluguel.Property(c => c.Encerrado)
            .IsRequired()
            .HasColumnType("bit");

        builderAluguel.Property(c => c.marcadorCombustivel)
           .HasColumnType("int")
           .IsRequired();

        builderAluguel.Property(c => c.GrupoId).HasColumnType("int").IsRequired();
        builderAluguel.Property(c => c.PlanoId).HasColumnType("int").IsRequired();
        builderAluguel.Property(c => c.VeiculoId).HasColumnType("int").IsRequired();
        builderAluguel.Property(c => c.CombustivelId).HasColumnType("int").IsRequired();
        builderAluguel.Property(c => c.CondutorId).HasColumnType("int").IsRequired();
        builderAluguel.Property(c => c.ClienteId).HasColumnType("int").IsRequired();

        builderAluguel.HasOne(a => a.Veiculo)
            .WithMany()
            .HasForeignKey(a => a.VeiculoId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builderAluguel.HasOne(a => a.Cliente)
            .WithMany()
            .HasForeignKey(a => a.ClienteId)
            .OnDelete(DeleteBehavior.NoAction);

        builderAluguel.HasOne(a => a.Condutor)
            .WithMany()
            .HasForeignKey(a => a.CondutorId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(); 
        
        builderAluguel.HasOne(a => a.Combustivel)
            .WithMany()
            .HasForeignKey(a => a.CombustivelId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builderAluguel.HasOne(c => c.Grupo)
            .WithMany()
            .HasForeignKey(c => c.GrupoId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builderAluguel.HasOne(c => c.Plano)
            .WithMany()
            .HasForeignKey(c => c.PlanoId)
            .OnDelete(DeleteBehavior.NoAction)
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