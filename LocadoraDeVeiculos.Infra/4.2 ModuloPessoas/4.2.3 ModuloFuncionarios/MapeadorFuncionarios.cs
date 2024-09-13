using Microsoft.EntityFrameworkCore;
using LocadoraDeVeiculos.Dominio.ModuloPessoas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;

public class MapeadorFuncionario : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builderFuncionario)
    {
        builderFuncionario.ToTable("TBFuncionario");

        builderFuncionario.Property(x => x.EmpresaId)
            .IsRequired()
            .HasColumnType("int")
            .HasColumnName("Empresa_Id");

        builderFuncionario.HasOne(x => x.Empresa)
            .WithMany()
            .HasForeignKey(x => x.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);


        builderFuncionario.Property(c => c.Id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builderFuncionario.Property(c => c.Nome)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builderFuncionario.Property(c => c.Email)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builderFuncionario.Property(c => c.DataAdimissao)
            .HasColumnType("datetime2")
            .IsRequired();

        builderFuncionario.Property(c => c.Salario)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builderFuncionario.Property(c => c.EmpresaId)
            .HasColumnType("int")
            .IsRequired();

        builderFuncionario.HasOne(c => c.Empresa)
            .WithMany()
            .HasForeignKey(f => f.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);

        builderFuncionario.Property(c => c.UsuarioId)
            .HasColumnType("int")
            .IsRequired();
    }
}