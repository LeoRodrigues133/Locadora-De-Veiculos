using LocadoraDeVeiculos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.ModuloPessoas;
public class MapeadorClientes : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builderCliente)
    {
        builderCliente.ToTable("TBCliente");

        builderCliente.Property(c => c.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builderCliente.Property(c => c.RG)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builderCliente.Property(c => c.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builderCliente.Property(c => c.Email)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builderCliente.Property(c => c.Telefone)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builderCliente.Property(c => c.Endereco)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builderCliente.Property(c => c.CPF)
            .IsRequired(false)
            .HasColumnType("varchar(14)");

        builderCliente.Property(c => c.CNPJ)
            .IsRequired(false)
            .HasColumnType("varchar(18)");

        builderCliente.Property(c => c.TipoPerfil)
            .IsRequired()
            .HasColumnType("bit");

        // Adiciona dados iniciais
        builderCliente.HasData(DefaultDataClientes());
    }

    private Cliente[] DefaultDataClientes()
    {
        return new[]
        {
                new Cliente
                {
                    Id = 1,
                    RG = "1.456.789",
                    Nome = "João Silva",
                    Email = "joao.silva@example.com",
                    Telefone = "(11) 91234-5678",
                    Endereco = "Rua A, 123",
                    CPF = "123.456.789-00",
                    CNPJ = null,
                    TipoPerfil = true
                },

                new Cliente
                {
                    Id = 2,
                    RG = "9.654.321",
                    Nome = "Maria Oliveira",
                    Email = "maria.oliveira@example.com",
                    Telefone = "(11) 99876-5432",
                    Endereco = "Rua B, 456",
                    CPF = "987.654.321-00",
                    CNPJ = null,
                    TipoPerfil = true
                },

                new Cliente
                {
                    Id = 3,
                    RG = "7.891.234",
                    Nome = "Carlos Santos",
                    Email = "carlos.santos@example.com",
                    Telefone = "(11) 91234-0000",
                    Endereco = "Rua E, 202",
                    CPF = "567.891.234-56",
                    CNPJ = null,
                    TipoPerfil = true
                },

                new Cliente
                {
                    Id = 4,
                    RG = "1.010.101",
                    Nome = "Ana Paula",
                    Email = "ana.paula@example.com",
                    Telefone = "(11) 91234-5679",
                    Endereco = "Rua G, 404",
                    CPF = "101.010.101-01",
                    CNPJ = null,
                    TipoPerfil = true
                },

                new Cliente
                {
                    Id = 5,
                    RG = "1.111.111",
                    Nome = "Pedro Almeida",
                    Email = "pedro.almeida@example.com",
                    Telefone = "(11) 97777-1111",
                    Endereco = "Rua H, 505",
                    CPF = "111.111.111-11",
                    CNPJ = null,
                    TipoPerfil = true
                },

                new Cliente
                {
                    Id = 6,
                    RG = "5.448.489",
                    Nome = "Comercial ABC",
                    Email = "comercial@abc.com",
                    Telefone = "(11) 98888-7777",
                    Endereco = "Rua F, 303",
                    CPF = null,
                    CNPJ = "00.111.222/0001-33",
                    TipoPerfil = false
                },

                new Cliente
                {
                    Id = 7,
                    RG = "4.894.984",
                    Nome = "Construtora LMN",
                    Email = "contato@lmn.com",
                    Telefone = "(11) 94444-5555",
                    Endereco = "Rua J, 707",
                    CPF = null,
                    CNPJ = "22.333.444/0001-55",
                    TipoPerfil = false
                },

                new Cliente
                {
                    Id = 8,
                    RG = "5.654.321",
                    Nome = "Tecnologia XYZ",
                    Email = "contato@tecnologiaxyz.com",
                    Telefone = "(11) 92222-4444",
                    Endereco = "Avenida I, 606",
                    CPF = null,
                    CNPJ = "11.222.333/0001-44",
                    TipoPerfil = false
                },

                new Cliente
                {
                    Id = 9,
                    RG = "1.156.854",
                    Nome = "Empresa X",
                    Email = "contato@empresax.com",
                    Telefone = "(11) 93456-7890",
                    Endereco = "Avenida C, 789",
                    CPF = null,
                    CNPJ = "12.345.678/0001-99",
                    TipoPerfil = false
                },

                new Cliente
                {
                    Id = 10,
                    RG = "4.984.888",
                    Nome = "Empresa Y",
                    Email = "contato@empresay.com",
                    Telefone = "(11) 97654-3210",
                    Endereco = "Avenida D, 101",
                    CPF = null,
                    CNPJ = "98.765.432/0001-88",
                    TipoPerfil = false
                },
            };
    }

}