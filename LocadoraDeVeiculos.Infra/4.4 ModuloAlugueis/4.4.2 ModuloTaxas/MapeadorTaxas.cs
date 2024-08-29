using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;

namespace LocadoraDeVeiculos.Infra.Compartilhado;
public class MapeadorTaxas : IEntityTypeConfiguration<TaxaServico>
{
    public void Configure(EntityTypeBuilder<TaxaServico> builderTaxas)
    {
        builderTaxas.ToTable("TBTaxasEServicos");

        builderTaxas.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builderTaxas.Property(t => t.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builderTaxas.Property(t => t.Valor)
            .IsRequired()
            .HasColumnType("decimal");

        builderTaxas.Property(t => t.TipoDeCobranca)
            .IsRequired()
            .HasColumnType("bit");
    }
}