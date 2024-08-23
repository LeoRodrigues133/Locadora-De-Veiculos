using Microsoft.EntityFrameworkCore;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Infra.Compartilhado
{
    public class MapeadorVeiculos : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> BuilderVeiculos)
        {
            BuilderVeiculos.ToTable("TBVeiculos");

            BuilderVeiculos.Property(v => v.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

            BuilderVeiculos.Property(v => v.Alugado)
                .IsRequired()
                .HasColumnType("bit");

            BuilderVeiculos.Property(v => v.Cor)
                .IsRequired()
                .HasColumnType("int");

            BuilderVeiculos.Property(v => v.Marca)
                .IsRequired()
                .HasColumnType("int");

            BuilderVeiculos.Property(v => v.CategoriaVeiculo)
                .IsRequired()
                .HasColumnType("int");

            BuilderVeiculos.Property(v => v.Combustivel)
                .IsRequired()
                .HasColumnType("int");

            BuilderVeiculos.Property(v => v.Ano)
                .IsRequired()
                .HasColumnType("int");

            BuilderVeiculos.Property(v => v.Placa)
                .IsRequired()
                .HasColumnType("Varchar(10)");

            BuilderVeiculos.Property(v => v.Modelo)
                .IsRequired()
                .HasColumnType("Varchar(20)");

            BuilderVeiculos.Property(v => v.Quilometragem)
                .IsRequired()
                .HasColumnType("int");

            BuilderVeiculos.Property(v => v.CapacidadeTanqueDeCombustivel)
                .IsRequired()
                .HasColumnType("int");

            BuilderVeiculos.Property(v => v.GrupoVeiculosId)
                .IsRequired()
                .HasColumnType("int");

            BuilderVeiculos.HasOne(v => v.GrupoVeiculos)
                .WithMany(g => g.Veiculos)
                .HasForeignKey(v => v.GrupoVeiculosId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}