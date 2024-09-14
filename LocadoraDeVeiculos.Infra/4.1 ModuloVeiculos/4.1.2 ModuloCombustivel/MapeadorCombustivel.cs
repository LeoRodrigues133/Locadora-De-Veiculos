using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;

namespace LocadoraDeVeiculos.Infra.ModuloVeiculos.ModuloCombustivel;

public class MapeadorCombustivel : IEntityTypeConfiguration<Combustivel>
{
    public void Configure(EntityTypeBuilder<Combustivel> builderCombustivel)
    {
        builderCombustivel.ToTable("TBCombustivel");

        builderCombustivel.Property(c => c.DataCriacao)
           .HasColumnType("datetime2")
           .IsRequired();

        builderCombustivel.Property(c => c.ValorGasolina)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builderCombustivel.Property(c => c.ValorGas)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builderCombustivel.Property(c => c.ValorDiesel)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builderCombustivel.Property(c => c.ValorAlcool)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builderCombustivel.Property(s => s.EmpresaId)
            .HasColumnType("int")
            .HasColumnName("Empresa_Id")
            .IsRequired();

        builderCombustivel.HasOne(g => g.Empresa)
            .WithMany()
            .HasForeignKey(s => s.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}