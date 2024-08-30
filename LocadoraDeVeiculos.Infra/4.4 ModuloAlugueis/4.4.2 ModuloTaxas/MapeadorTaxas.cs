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


        // Adiciona dados iniciais
        builderTaxas.HasData(DefaultDataTaxas());
    }

    private TaxaServico[] DefaultDataTaxas()
    {
        return new[]
        {
                // Taxas Fixas
                new TaxaServico { Id = 1, Nome = "Taxa de Limpeza", Valor = 50, TipoDeCobranca = true },
                new TaxaServico { Id = 2, Nome = "Taxa de Seguro", Valor = 150, TipoDeCobranca = true },
                new TaxaServico { Id = 7, Nome = "Taxa de Cancelamento", Valor = 100, TipoDeCobranca = true },
                new TaxaServico { Id = 5, Nome = "Taxa de Administração", Valor = 200, TipoDeCobranca = true },
                new TaxaServico { Id = 4, Nome = "Taxa de Entrega Especial", Valor = 120, TipoDeCobranca = true },
                new TaxaServico { Id = 8, Nome = "Taxa de Reservas Especiais", Valor = 75, TipoDeCobranca = true },
                new TaxaServico { Id = 6, Nome = "Taxa de Retorno Antecipado", Valor = 60, TipoDeCobranca = true },
                new TaxaServico { Id = 9, Nome = "Taxa de Condução Adicional", Valor = 40, TipoDeCobranca = true },
                new TaxaServico { Id = 3, Nome = "Taxa de Atendimento Noturno", Valor = 80, TipoDeCobranca = true },
                new TaxaServico { Id = 10, Nome = "Taxa de Expedição de Documentos", Valor = 90, TipoDeCobranca = true },

                // Taxas Diárias
                new TaxaServico { Id = 11, Nome = "Taxa de GPS", Valor = 15, TipoDeCobranca = false },
                new TaxaServico { Id = 14, Nome = "Taxa de Pedágio", Valor = 10, TipoDeCobranca = false },
                new TaxaServico { Id = 17, Nome = "Taxa de Seguro Adicional", Valor = 40, TipoDeCobranca = false },
                new TaxaServico { Id = 12, Nome = "Taxa de Assento Infantil", Valor = 20, TipoDeCobranca = false },
                new TaxaServico { Id = 15, Nome = "Taxa de Combustível Extra", Valor = 30, TipoDeCobranca = false },
                new TaxaServico { Id = 19, Nome = "Taxa de Seguro contra Danos", Valor = 50, TipoDeCobranca = false },
                new TaxaServico { Id = 13, Nome = "Taxa de Adicional de Condutor", Valor = 25, TipoDeCobranca = false },
                new TaxaServico { Id = 20, Nome = "Taxa de Trajeto Internacional", Valor = 60, TipoDeCobranca = false },
                new TaxaServico { Id = 16, Nome = "Taxa de Equipamento de Segurança", Valor = 35, TipoDeCobranca = false },
                new TaxaServico { Id = 18, Nome = "Taxa de Kit de Primeiros Socorros", Valor = 18, TipoDeCobranca = false },
            };
    }
}
