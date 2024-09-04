using Microsoft.EntityFrameworkCore;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Compartilhado
{
    public class MapeadorVeiculos : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builderVeiculos)
        {
            builderVeiculos.ToTable("TBVeiculos");

            builderVeiculos.Property(v => v.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

            builderVeiculos.Property(v => v.Alugado)
                .IsRequired()
                .HasColumnType("bit");

            builderVeiculos.Property(v => v.Cor)
                .IsRequired()
                .HasColumnType("int");

            builderVeiculos.Property(v => v.Marca)
                .IsRequired()
                .HasColumnType("int");

            builderVeiculos.Property(v => v.Combustivel)
                .IsRequired()
                .HasColumnType("int");

            builderVeiculos.Property(v => v.Ano)
                .IsRequired()
                .HasColumnType("int");

            builderVeiculos.Property(v => v.Placa)
                .IsRequired()
                .HasColumnType("Varchar(10)");

            builderVeiculos.Property(v => v.Modelo)
                .IsRequired()
                .HasColumnType("Varchar(20)");

            builderVeiculos.Property(v => v.Quilometragem)
                .IsRequired()
                .HasColumnType("int");

            builderVeiculos.Property(v => v.CapacidadeTanqueDeCombustivel)
                .IsRequired()
                .HasColumnType("int");

            builderVeiculos.Property(v => v.GrupoVeiculosId)
                .IsRequired()
                .HasColumnType("int");

            builderVeiculos.HasOne(v => v.GrupoVeiculos)
                .WithMany(g => g.Veiculos)
                .HasForeignKey(v => v.GrupoVeiculosId)
                .OnDelete(DeleteBehavior.Restrict);

            //builderVeiculos.Property(v => v.Foto)
            //    .HasColumnType("varbinary(max)")
            //    .HasDefaultValue(Array.Empty<byte>());

        }

    }

}