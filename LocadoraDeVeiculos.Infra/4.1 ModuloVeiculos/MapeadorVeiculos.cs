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


            // Adiciona dados iniciais
            builderVeiculos.HasData(DefaultDataVeiculos());
        }

        private Veiculo[] DefaultDataVeiculos()
        {
            return new[]
            {
            // Volkswagen
            new Veiculo
            {
                Id = 1,
                Cor = Cor.Preto,
                Marca = Marca.Volkswagen,
                Combustivel = Combustivel.Gasolina,
                GrupoVeiculosId = 1,
                Ano = 2022,
                Alugado = false,
                Placa = "ABC1D23",
                Modelo = "Gol",
                Quilometragem = 10000,
                CapacidadeTanqueDeCombustivel = 50
            },
            new Veiculo
            {
                Id = 2,
                Cor = Cor.Branco,
                Marca = Marca.Volkswagen,
                Combustivel = Combustivel.Flex,
                GrupoVeiculosId = 1,
                Ano = 2021,
                Alugado = false,
                Placa = "DEF4G56",
                Modelo = "Virtus",
                Quilometragem = 5000,
                CapacidadeTanqueDeCombustivel = 55
            },
            new Veiculo
            {
                Id = 3,
                Cor = Cor.Prata,
                Marca = Marca.Volkswagen,
                Combustivel = Combustivel.Diesel,
                GrupoVeiculosId = 2,
                Ano = 2020,
                Alugado = true,
                Placa = "GHI7J89",
                Modelo = "Tiguan",
                Quilometragem = 25000,
                CapacidadeTanqueDeCombustivel = 60
            },
            new Veiculo
            {
                Id = 4,
                Cor = Cor.Vermelho,
                Marca = Marca.Volkswagen,
                Combustivel = Combustivel.Etanol,
                GrupoVeiculosId = 2,
                Ano = 2019,
                Alugado = false,
                Placa = "JKL0M12",
                Modelo = "Polo",
                Quilometragem = 30000,
                CapacidadeTanqueDeCombustivel = 50
            },

            // Fiat
            new Veiculo
            {
                Id = 5,
                Cor = Cor.Azul,
                Marca = Marca.Fiat,
                Combustivel = Combustivel.Flex,
                GrupoVeiculosId = 3,
                Ano = 2023,
                Alugado = false,
                Placa = "MNO3P45",
                Modelo = "Uno",
                Quilometragem = 5000,
                CapacidadeTanqueDeCombustivel = 48
            },
            new Veiculo
            {
                Id = 6,
                Cor = Cor.Cinza,
                Marca = Marca.Fiat,
                Combustivel = Combustivel.Gasolina,
                GrupoVeiculosId = 3,
                Ano = 2022,
                Alugado = false,
                Placa = "PQR6S78",
                Modelo = "Argo",
                Quilometragem = 10000,
                CapacidadeTanqueDeCombustivel = 45
            },
            new Veiculo
            {
                Id = 7,
                Cor = Cor.Branco,
                Marca = Marca.Fiat,
                Combustivel = Combustivel.Etanol,
                GrupoVeiculosId = 4,
                Ano = 2021,
                Alugado = true,
                Placa = "STU9V01",
                Modelo = "Toro",
                Quilometragem = 20000,
                CapacidadeTanqueDeCombustivel = 60
            },
            new Veiculo
            {
                Id = 8,
                Cor = Cor.Preto,
                Marca = Marca.Fiat,
                Combustivel = Combustivel.Diesel,
                GrupoVeiculosId = 4,
                Ano = 2020,
                Alugado = false,
                Placa = "VWX2Y34",
                Modelo = "Freemont",
                Quilometragem = 35000,
                CapacidadeTanqueDeCombustivel = 70
            },

            // Chevrolet
            new Veiculo
            {
                Id = 9,
                Cor = Cor.Vermelho,
                Marca = Marca.Chevrolet,
                Combustivel = Combustivel.Gasolina,
                GrupoVeiculosId = 5,
                Ano = 2022,
                Alugado = false,
                Placa = "XYZ5Z67",
                Modelo = "Onix",
                Quilometragem = 12000,
                CapacidadeTanqueDeCombustivel = 45
            },
            new Veiculo
            {
                Id = 10,
                Cor = Cor.Prata,
                Marca = Marca.Chevrolet,
                Combustivel = Combustivel.Flex,
                GrupoVeiculosId = 5,
                Ano = 2021,
                Alugado = false,
                Placa = "ABC8D90",
                Modelo = "Tracker",
                Quilometragem = 8000,
                CapacidadeTanqueDeCombustivel = 50
            },
            new Veiculo
            {
                Id = 11,
                Cor = Cor.Cinza,
                Marca = Marca.Chevrolet,
                Combustivel = Combustivel.Diesel,
                GrupoVeiculosId = 6,
                Ano = 2020,
                Alugado = true,
                Placa = "DEF1G23",
                Modelo = "S10",
                Quilometragem = 22000,
                CapacidadeTanqueDeCombustivel = 60
            },
            new Veiculo
            {
                Id = 12,
                Cor = Cor.Azul,
                Marca = Marca.Chevrolet,
                Combustivel = Combustivel.Etanol,
                GrupoVeiculosId = 6,
                Ano = 2019,
                Alugado = false,
                Placa = "GHI4J56",
                Modelo = "Cruze",
                Quilometragem = 40000,
                CapacidadeTanqueDeCombustivel = 55
            },

            // Ford
            new Veiculo
            {
                Id = 13,
                Cor = Cor.Branco,
                Marca = Marca.Ford,
                Combustivel = Combustivel.Gasolina,
                GrupoVeiculosId = 7,
                Ano = 2023,
                Alugado = false,
                Placa = "JKL7M89",
                Modelo = "Ka",
                Quilometragem = 7000,
                CapacidadeTanqueDeCombustivel = 40
            },
            new Veiculo
            {
                Id = 14,
                Cor = Cor.Preto,
                Marca = Marca.Ford,
                Combustivel = Combustivel.Flex,
                GrupoVeiculosId = 7,
                Ano = 2022,
                Alugado = false,
                Placa = "MNO8P01",
                Modelo = "EcoSport",
                Quilometragem = 15000,
                CapacidadeTanqueDeCombustivel = 50
            },
            new Veiculo
            {
                Id = 15,
                Cor = Cor.Cinza,
                Marca = Marca.Ford,
                Combustivel = Combustivel.Diesel,
                GrupoVeiculosId = 8,
                Ano = 2021,
                Alugado = true,
                Placa = "PQR9S23",
                Modelo = "Ranger",
                Quilometragem = 30000,
                CapacidadeTanqueDeCombustivel = 70

            }

        };
        }
    }
}