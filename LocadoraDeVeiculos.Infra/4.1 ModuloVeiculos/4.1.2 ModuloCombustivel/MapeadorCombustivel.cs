using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;

namespace LocadoraDeVeiculos.Infra.ModuloVeiculos.ModuloCombustivel;

public class MapeadorAlugueis : IEntityTypeConfiguration<Combustivel>
{
    public void Configure(EntityTypeBuilder<Combustivel> builderCombustivel)
    {
        builderCombustivel.ToTable("TBCombustivel");

        builderCombustivel.Property(x => x.EmpresaId)
            .IsRequired()
            .HasColumnType("int")
            .HasColumnName("Empresa_Id");

        builderCombustivel.HasOne(x => x.Empresa)
            .WithMany()
            .HasForeignKey(x => x.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);


        builderCombustivel.Property(c => c.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builderCombustivel.Property(c => c.Preco)
            .IsRequired()
            .HasColumnType("decimal");

        builderCombustivel.Property(c => c.Nome)
            .IsRequired()
            .HasColumnType("int");


    }
}
