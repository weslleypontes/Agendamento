
using Agendamento.Domain.Entities.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamento.Infrastructure.Configurations.Empresas;

public class ExcecaoFuncionamentoConfiguration
    : IEntityTypeConfiguration<ExcecaoFuncionamento>
{
    public void Configure(EntityTypeBuilder<ExcecaoFuncionamento> builder)
    {
        builder.ToTable("ExcecaoFuncionamento", table =>
        {
            table.HasCheckConstraint(
                "CK_ExcecaoFuncionamento_Data",
                "[DataFim] >= [DataInicio]");

            table.HasCheckConstraint(
                "CK_ExcecaoFuncionamento_Tipo",
                "[Tipo] IN (1, 2)");
        });

        // Chave primária
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        // Unidade
        builder.Property(e => e.UnidadeId)
            .IsRequired();

        builder.HasOne(e => e.Unidade)
            .WithMany(u => u.ExcecoesFuncionamento)
            .HasForeignKey(e => e.UnidadeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Período da exceção
        builder.Property(e => e.DataInicio)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(e => e.DataFim)
            .HasColumnType("date")
            .IsRequired();

        // Tipo:
        // 1 = Fechamento
        // 2 = Horário especial
        builder.Property(e => e.Tipo)
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(e => e.Motivo)
            .HasMaxLength(300);

        // Relacionamento com períodos excepcionais
        builder.HasMany(e => e.Periodos)
            .WithOne(p => p.ExcecaoFuncionamento)
            .HasForeignKey(p => p.ExcecaoFuncionamentoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Índice para consulta das exceções por unidade e data
        builder.HasIndex(e => new
        {
            e.UnidadeId,
            e.DataInicio,
            e.DataFim
        })
            .HasDatabaseName(
                "IX_ExcecaoFuncionamento_Unidade_Data");
    }
}
