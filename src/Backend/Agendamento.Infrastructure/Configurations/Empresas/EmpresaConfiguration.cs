using Agendamento.Domain.Entities.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamento.Infrastructure.Configurations.Empresas;

public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("Empresa");

        // Chave primária
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        // Dados cadastrais
        builder.Property(e => e.RazaoSocial)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.NomeFantasia)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.Cnpj)
            .HasColumnType("varchar(14)")
            .IsRequired();

        builder.Property(e => e.Email)
            .HasMaxLength(150);

        builder.Property(e => e.Telefone)
            .HasColumnType("varchar(20)");

        // Controle
        builder.Property(e => e.Ativa)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.DataCadastro)
            .HasColumnType("datetime2(0)")
            .HasDefaultValueSql("SYSUTCDATETIME()")
            .IsRequired();

        builder.Property(e => e.DataAtualizacao)
            .HasColumnType("datetime2(0)");

        // Índices
        builder.HasIndex(e => e.Cnpj)
            .IsUnique()
            .HasDatabaseName("UX_Empresa_Cnpj");

        builder.HasIndex(e => e.Ativa)
            .HasDatabaseName("IX_Empresa_Ativa");

        // Empresa 1:N Unidade
        builder.HasMany(e => e.Unidades)
            .WithOne(u => u.Empresa)
            .HasForeignKey(u => u.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Empresa 1:N AuditoriaEmpresa
        builder.HasMany(e => e.Auditorias)
            .WithOne(a => a.Empresa)
            .HasForeignKey(a => a.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}