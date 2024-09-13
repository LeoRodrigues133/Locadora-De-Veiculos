using LocadoraDeVeiculos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Compartilhado;
public class MapeadorPlanos : IEntityTypeConfiguration<Plano>
{
    public void Configure(EntityTypeBuilder<Plano> builderPlano)
    {
        builderPlano.ToTable("TBPlano");

        builderPlano.Property(x => x.EmpresaId)
            .IsRequired()
            .HasColumnType("int")
            .HasColumnName("Empresa_Id");

        builderPlano.HasOne(x => x.Empresa)
            .WithMany()
            .HasForeignKey(x => x.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);


        builderPlano.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builderPlano.Property(p => p.TipoPlano)
            .IsRequired()
            .HasColumnType("int");

        builderPlano.Property(p => p.PrecoKm)
            .HasColumnType("decimal")
            .IsRequired(false);

        builderPlano.Property(p => p.ValorDiaria)
            .HasColumnType("decimal")
            .IsRequired(false);


        builderPlano.Property(p => p.ValorExtrapolado)
            .HasColumnType("decimal")
            .IsRequired(false);

        builderPlano.Property(p => p.KmDisponivel)
            .HasColumnType("int")
            .IsRequired(false);

        builderPlano.Property(p => p.GrupoVeiculosId)
            .IsRequired()
            .HasColumnType("int");

        builderPlano.HasOne(p => p.GrupoVeiculos)
            .WithMany()
            .IsRequired()
            .HasForeignKey(p => p.GrupoVeiculosId)
            .OnDelete(DeleteBehavior.Restrict);

        // Adiciona dados iniciais
        //builderPlano.HasData(DefaultDataPlanos());
    }

    private Plano[] DefaultDataPlanos()
    {
        return new[]
        {
            new Plano { Id = 1, TipoPlano = TipoPlano.Diario, PrecoKm = null,
                ValorDiaria = 100, ValorExtrapolado = 20, KmDisponivel = 300, GrupoVeiculosId = 1 },

            new Plano { Id = 2, TipoPlano = TipoPlano.Controlado, PrecoKm = 10,
                ValorDiaria = 150, ValorExtrapolado = 30, KmDisponivel = 500, GrupoVeiculosId = 2 },

            new Plano { Id = 3, TipoPlano = TipoPlano.Livre, PrecoKm = 15,
                ValorDiaria = 200, ValorExtrapolado = 40, KmDisponivel = 700, GrupoVeiculosId = 3 },

            new Plano { Id = 4, TipoPlano = TipoPlano.Diario, PrecoKm = null,
                ValorDiaria = 250, ValorExtrapolado = 50, KmDisponivel = 1000, GrupoVeiculosId = 4 },

            new Plano { Id = 5, TipoPlano = TipoPlano.Controlado, PrecoKm = 12,
                ValorDiaria = 120, ValorExtrapolado = 25, KmDisponivel = 400, GrupoVeiculosId = 5 },

            new Plano { Id = 6, TipoPlano = TipoPlano.Livre, PrecoKm = 18,
                ValorDiaria = 180, ValorExtrapolado = 35, KmDisponivel = 600, GrupoVeiculosId = 6 },

            new Plano { Id = 7, TipoPlano = TipoPlano.Diario, PrecoKm = null,
                ValorDiaria = 230, ValorExtrapolado = 45, KmDisponivel = 800, GrupoVeiculosId = 7 },

            new Plano { Id = 8, TipoPlano = TipoPlano.Controlado, PrecoKm = 20,
                ValorDiaria = 270, ValorExtrapolado = 55, KmDisponivel = 1100, GrupoVeiculosId = 8 },

            new Plano { Id = 9, TipoPlano = TipoPlano.Livre, PrecoKm = 25,
                ValorDiaria = 130, ValorExtrapolado = 30, KmDisponivel = 350, GrupoVeiculosId = 9 },

            new Plano { Id = 10, TipoPlano = TipoPlano.Diario, PrecoKm = null,
                ValorDiaria = 190, ValorExtrapolado = 40, KmDisponivel = 650, GrupoVeiculosId = 10 }
        };
    }
}