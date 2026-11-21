
using Agendamento.Domain.Entities.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamento.Infrastructure.Configurations.Clientes;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente", table =>
        {
            table.HasCheckConstraint(
                "CK_Cliente_TipoPessoa",
                "[TipoPessoa] IN ('F', 'J')");

            table.HasCheckConstraint(
                "CK_Cliente_Documento",
                "[Documento] IS NULL OR " +
                "([TipoPessoa] = 'F' AND LEN([Documento]) = 11) OR " +
                "([TipoPessoa] = 'J' AND LEN([Documento]) = 14)");
        });

        // Chave primária
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        // Chave alternativa para relacionamentos entre empresas
        builder.HasAlternateKey(c => new { c.EmpresaId, c.Id })
            .HasName("AK_Cliente_EmpresaId_Id");

        // Empresa
        builder.Property(c => c.EmpresaId)
            .IsRequired();

        builder.HasOne(c => c.Empresa)
            .WithMany(e => e.Clientes)
            .HasForeignKey(c => c.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Tipo de pessoa
        builder.Property(c => c.TipoPessoa)
            .HasColumnType("char(1)")
            .IsRequired();

        // Dados cadastrais
        builder.Property(c => c.Nome)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.Telefone)
            .HasColumnType("varchar(20)");

        builder.Property(c => c.Email)
            .HasMaxLength(150);

        builder.Property(c => c.Documento)
            .HasColumnType("varchar(14)");

        builder.Property(c => c.DataNascimento)
            .HasColumnType("date");

        builder.Property(c => c.Observacoes)
            .HasMaxLength(1000);

        // Controle
        builder.Property(c => c.Ativo)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(c => c.DataCadastro)
            .HasColumnType("datetime2(0)")
            .HasDefaultValueSql("SYSUTCDATETIME()")
            .IsRequired();

        builder.Property(c => c.DataAtualizacao)
            .HasColumnType("datetime2(0)");

        // Documento único dentro da empresa, quando informado
        builder.HasIndex(c => new
        {
            c.EmpresaId,
            c.Documento
        })
            .IsUnique()
            .HasDatabaseName("UX_Cliente_Empresa_Documento")
            .HasFilter("[Documento] IS NOT NULL");

        // Índices auxiliares
        builder.HasIndex(c => c.EmpresaId)
            .HasDatabaseName("IX_Cliente_EmpresaId");

        builder.HasIndex(c => new
        {
            c.EmpresaId,
            c.Nome
        })
            .HasDatabaseName("IX_Cliente_Empresa_Nome");
    }
}
