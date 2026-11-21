
using Agendamento.Domain.Entities.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamento.Infrastructure.Configurations.Empresas;

public class AuditoriaEmpresaConfiguration
    : IEntityTypeConfiguration<AuditoriaEmpresa>
{
    public void Configure(EntityTypeBuilder<AuditoriaEmpresa> builder)
    {
        builder.ToTable("AuditoriaEmpresa");

        // Chave primária
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        // Empresa
        builder.Property(a => a.EmpresaId)
            .IsRequired();

        builder.HasOne(a => a.Empresa)
            .WithMany(e => e.Auditorias)
            .HasForeignKey(a => a.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Usuário responsável pela alteração
        builder.Property(a => a.UsuarioId);

        // Dados da alteração
        builder.Property(a => a.CampoAlterado)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.ValorAnterior)
            .HasMaxLength(500);

        builder.Property(a => a.ValorNovo)
            .HasMaxLength(500);

        builder.Property(a => a.DataAlteracao)
            .HasColumnType("datetime2(0)")
            .HasDefaultValueSql("SYSUTCDATETIME()")
            .IsRequired();

        // Índices
        builder.HasIndex(a => new
        {
            a.EmpresaId,
            a.DataAlteracao
        })
            .HasDatabaseName(
                "IX_AuditoriaEmpresa_Empresa_DataAlteracao");

        builder.HasIndex(a => a.UsuarioId)
            .HasDatabaseName(
                "IX_AuditoriaEmpresa_UsuarioId");
    }
}
