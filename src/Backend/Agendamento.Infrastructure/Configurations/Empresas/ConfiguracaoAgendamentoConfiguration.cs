
using Agendamento.Domain.Entities.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamento.Infrastructure.Configurations.Empresas;

public class ConfiguracaoAgendamentoConfiguration
    : IEntityTypeConfiguration<ConfiguracaoAgendamento>
{
    public void Configure(
        EntityTypeBuilder<ConfiguracaoAgendamento> builder)
    {
        builder.ToTable("ConfiguracaoAgendamento", table =>
        {
            table.HasCheckConstraint(
                "CK_ConfiguracaoAgendamento_AntecedenciaMinima",
                "[AntecedenciaMinimaHoras] >= 0");

            table.HasCheckConstraint(
                "CK_ConfiguracaoAgendamento_AntecedenciaMaxima",
                "[AntecedenciaMaximaDias] > 0");

            table.HasCheckConstraint(
                "CK_ConfiguracaoAgendamento_Intervalo",
                "[IntervaloEntreAtendimentosMinutos] >= 0");

            table.HasCheckConstraint(
                "CK_ConfiguracaoAgendamento_PrazoCancelamento",
                "[PrazoCancelamentoHoras] >= 0");

            table.HasCheckConstraint(
                "CK_ConfiguracaoAgendamento_PrazoReagendamento",
                "[PrazoReagendamentoHoras] >= 0");
        });

        // Chave primária
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        // Unidade
        builder.Property(c => c.UnidadeId)
            .IsRequired();

        // Uma configuração por unidade
        builder.HasIndex(c => c.UnidadeId)
            .IsUnique()
            .HasDatabaseName(
                "UX_ConfiguracaoAgendamento_UnidadeId");

        // Antecedência
        builder.Property(c => c.AntecedenciaMinimaHoras)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(c => c.AntecedenciaMaximaDias)
            .IsRequired();

        // Intervalo entre atendimentos
        builder.Property(c => c.IntervaloEntreAtendimentosMinutos)
            .HasDefaultValue(0)
            .IsRequired();

        // Agendamento no mesmo dia
        builder.Property(c => c.PermiteAgendamentoMesmoDia)
            .HasDefaultValue(true)
            .IsRequired();

        // Cancelamento
        builder.Property(c => c.PrazoCancelamentoHoras)
            .HasDefaultValue(0)
            .IsRequired();

        // Reagendamento
        builder.Property(c => c.PermiteReagendamento)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(c => c.PrazoReagendamentoHoras)
            .HasDefaultValue(0)
            .IsRequired();

        // Confirmação
        builder.Property(c => c.ConfirmacaoAutomatica)
            .HasDefaultValue(false)
            .IsRequired();
    }
}
