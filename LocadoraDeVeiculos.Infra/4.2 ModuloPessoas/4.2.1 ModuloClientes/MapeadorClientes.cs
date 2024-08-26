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



    //public string RG { get; set; }
    //public string Nome { get; set; }
    //public string Email { get; set; }
    //public string Telefone { get; set; }
    //public string Endereco { get; set; }
    //public bool TipoPerfil { get; set; }
    //public string? CPF { get; set; }
    //public string? CNPJ { get; set; }
}
}
