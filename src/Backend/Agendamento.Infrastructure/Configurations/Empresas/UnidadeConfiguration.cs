
using Agendamento.Domain.Entities.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamento.Infrastructure.Configurations.Empresas;

public class UnidadeConfiguration : IEntityTypeConfiguration<Unidade>
{
    public void Configure(EntityTypeBuilder<Unidade> builder)
    {
        builder.ToTable("Unidade");

        // Chave primária
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd();

        // Relacionamento com Empresa
        builder.Property(u => u.EmpresaId)
            .IsRequired();

        builder.HasOne(u => u.Empresa)
            .WithMany(e => e.Unidades)
            .HasForeignKey(u => u.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Chave alternativa para relacionamentos compostos
        builder.HasAlternateKey(u => new { u.EmpresaId, u.Id })
            .HasName("AK_Unidade_EmpresaId_Id");

        // Dados cadastrais
        builder.Property(u => u.Nome)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(u => u.Cnpj)
            .HasColumnType("varchar(14)");

        builder.Property(u => u.Telefone)
            .HasColumnType("varchar(20)");

        builder.Property(u => u.Email)
            .HasMaxLength(150);

        // Endereço
        builder.Property(u => u.Cep)
            .HasColumnType("varchar(8)");

        builder.Property(u => u.Logradouro)
            .HasMaxLength(200);

        builder.Property(u => u.Numero)
            .HasMaxLength(20);

        builder.Property(u => u.Complemento)
            .HasMaxLength(100);

        builder.Property(u => u.Bairro)
            .HasMaxLength(100);

        builder.Property(u => u.Cidade)
            .HasMaxLength(100);

        builder.Property(u => u.Estado)
            .HasColumnType("char(2)");

        // Fuso horário obrigatório
        builder.Property(u => u.FusoHorario)
            .HasMaxLength(100)
            .IsRequired();

        // Controle
        builder.Property(u => u.Ativa)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(u => u.DataCadastro)
            .HasColumnType("datetime2(0)")
            .HasDefaultValueSql("SYSUTCDATETIME()")
            .IsRequired();

        builder.Property(u => u.DataAtualizacao)
            .HasColumnType("datetime2(0)");

        // Índices
        builder.HasIndex(u => u.EmpresaId)
            .HasDatabaseName("IX_Unidade_EmpresaId");

        builder.HasIndex(u => new { u.EmpresaId, u.Ativa })
            .HasDatabaseName("IX_Unidade_EmpresaId_Ativa");

        builder.HasIndex(u => u.Cnpj)
            .IsUnique()
            .HasDatabaseName("UX_Unidade_Cnpj")
            .HasFilter("[Cnpj] IS NOT NULL");

        // Relacionamento 1:1 com ConfiguracaoAgendamento
        builder.HasOne(u => u.ConfiguracaoAgendamento)
            .WithOne(c => c.Unidade)
            .HasForeignKey<ConfiguracaoAgendamento>(c => c.UnidadeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento 1:N com HorarioFuncionamento
        builder.HasMany(u => u.HorariosFuncionamento)
            .WithOne(h => h.Unidade)
            .HasForeignKey(h => h.UnidadeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento 1:N com ExcecaoFuncionamento
        builder.HasMany(u => u.ExcecoesFuncionamento)
            .WithOne(e => e.Unidade)
            .HasForeignKey(e => e.UnidadeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
