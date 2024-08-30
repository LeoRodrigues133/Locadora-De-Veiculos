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

        // Adiciona dados iniciais
        builderCondutor.HasData(DefaultDataCondutores());
    }

    private Condutor[] DefaultDataCondutores()
    {
        return new[]
        {
            // Condutores com CPF
            new Condutor
            {
                Id = 1,
                Nome = "João Silva",
                CPF = "123.456.789-00",
                Telefone = "(11) 91234-5678",
                Email = "joao.silva@example.com",
                CNH = "CNH12345678",
                ValidadeCNH = new DateTime(2025, 12, 31),
                ClienteCondutor = true,
                ClienteId = 1
            },
            new Condutor
            {
                Id = 2,
                Nome = "Maria Oliveira",
                CPF = "987.654.321-00",
                Telefone = "(11) 99876-5432",
                Email = "maria.oliveira@example.com",
                CNH = "CNH23456789",
                ValidadeCNH = new DateTime(2024, 11, 30),
                ClienteCondutor = true,
                ClienteId = 2
            },
            new Condutor
            {
                Id = 3,
                Nome = "Carlos Santos",
                CPF = "567.891.234-56",
                Telefone = "(11) 91234-0000",
                Email = "carlos.santos@example.com",
                CNH = "CNH34567890",
                ValidadeCNH = new DateTime(2026, 05, 20),
                ClienteCondutor = true,
                ClienteId = 5
            },
            new Condutor
            {
                Id = 4,
                Nome = "Ana Paula",
                CPF = "101.010.101-01",
                Telefone = "(11) 91234-5679",
                Email = "ana.paula@example.com",
                CNH = "CNH45678901",
                ValidadeCNH = new DateTime(2024, 09, 15),
                ClienteCondutor = true,
                ClienteId = 7
            },
            new Condutor
            {
                Id = 5,
                Nome = "Pedro Almeida",
                CPF = "111.111.111-11",
                Telefone = "(11) 97777-1111",
                Email = "pedro.almeida@example.com",
                CNH = "CNH56789012",
                ValidadeCNH = new DateTime(2025, 08, 30),
                ClienteCondutor = true,
                ClienteId = 8
            },

            // Condutores com CNPJ
            new Condutor
            {
                Id = 6,
                Nome = "Condutor Comercial ABC 1",
                Telefone = "(11) 98888-7777",
                Email = "condutor1@abc.com",
                CNH = "CNH67890123",
                ValidadeCNH = new DateTime(2023, 12, 31),
                ClienteCondutor = false,
                ClienteId = 6
            },
            new Condutor
            {
                Id = 7,
                Nome = "Condutor Comercial ABC 2",
                Telefone = "(11) 98888-7778",
                Email = "condutor2@abc.com",
                CNH = "CNH78901234",
                ValidadeCNH = new DateTime(2024, 01, 15),
                ClienteCondutor = false,
                ClienteId = 6
            },
            new Condutor
            {
                Id = 8,
                Nome = "Condutor Comercial ABC 3",
                Telefone = "(11) 98888-7779",
                Email = "condutor3@abc.com",
                CNH = "CNH89012345",
                ValidadeCNH = new DateTime(2025, 02, 28),
                ClienteCondutor = false,
                ClienteId = 6
            },

            new Condutor
            {
                Id = 9,
                Nome = "Condutor Construtora LMN 1",
                Telefone = "(11) 94444-5555",
                Email = "condutor1@lmn.com",
                CNH = "CNH90123456",
                ValidadeCNH = new DateTime(2024, 06, 30),
                ClienteCondutor = false,
                ClienteId = 10
            },
            new Condutor
            {
                Id = 10,
                Nome = "Condutor Construtora LMN 2",
                Telefone = "(11) 94444-5556",
                Email = "condutor2@lmn.com",
                CNH = "CNH01234567",
                ValidadeCNH = new DateTime(2024, 07, 15),
                ClienteCondutor = false,
                ClienteId = 10
            },
            new Condutor
            {
                Id = 11,
                Nome = "Condutor Construtora LMN 3",
                Telefone = "(11) 94444-5557",
                Email = "condutor3@lmn.com",
                CNH = "CNH12345678",
                ValidadeCNH = new DateTime(2024, 08, 20),
                ClienteCondutor = false,
                ClienteId = 10
            },

            new Condutor
            {
                Id = 12,
                Nome = "Condutor Tecnologia XYZ 1",
                Telefone = "(11) 92222-4444",
                Email = "condutor1@tecnologiaxyz.com",
                CNH = "CNH23456789",
                ValidadeCNH = new DateTime(2025, 03, 31),
                ClienteCondutor = false,
                ClienteId = 9
            },
            new Condutor
            {
                Id = 13,
                Nome = "Condutor Tecnologia XYZ 2",
                Telefone = "(11) 92222-4445",
                Email = "condutor2@tecnologiaxyz.com",
                CNH = "CNH34567890",
                ValidadeCNH = new DateTime(2025, 04, 30),
                ClienteCondutor = false,
                ClienteId = 9
            },
            new Condutor
            {
                Id = 14,
                Nome = "Condutor Tecnologia XYZ 3",
                Telefone = "(11) 92222-4446",
                Email = "condutor3@tecnologiaxyz.com",
                CNH = "CNH45678901",
                ValidadeCNH = new DateTime(2025, 05, 31),
                ClienteCondutor = false,
                ClienteId = 9
            }
        };
    }
}