using LocadoraDeVeiculos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MapeadorCondutores : IEntityTypeConfiguration<Condutor>
{
    public void Configure(EntityTypeBuilder<Condutor> builderCondutor)
    {
        builderCondutor.ToTable("TBCondutor");

        builderCondutor.Property(c => c.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builderCondutor.Property(c => c.Nome)
            .IsRequired(false)
            .HasColumnType("varchar(100))");

        builderCondutor.Property(c => c.CPF)
            .IsRequired(false)
            .HasColumnType("varchar(15))");

        builderCondutor.Property(c => c.Telefone)
             .IsRequired(false)
             .HasColumnType("varchar(17))");

        builderCondutor.Property(c => c.Email)
            .IsRequired(false)
            .HasColumnType("varchar(100))");

        builderCondutor.Property(c => c.CNH)
            .IsRequired()
            .HasColumnType("varchar(14))");

        builderCondutor.Property(c => c.ValidadeCNH)
            .IsRequired()
            .HasColumnType("date");

        builderCondutor.Property(c => c.ClienteCondutor)
            .IsRequired()
            .HasColumnType("bit");

        builderCondutor.Property(c => c.ClienteId)
            .IsRequired()
            .HasColumnType("int");

        builderCondutor.HasOne(c => c.Cliente)
            .WithMany()
            .HasForeignKey(c => c.ClienteId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}