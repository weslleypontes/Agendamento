
using Agendamento.Domain.Entities.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamento.Infrastructure.Configurations.Empresas;

public class HorarioFuncionamentoConfiguration
    : IEntityTypeConfiguration<HorarioFuncionamento>
{
    public void Configure(EntityTypeBuilder<HorarioFuncionamento> builder)
    {
        builder.ToTable("HorarioFuncionamento", table =>
        {
            table.HasCheckConstraint(
                "CK_HorarioFuncionamento_DiaSemana",
                "[DiaSemana] BETWEEN 0 AND 6");

            table.HasCheckConstraint(
                "CK_HorarioFuncionamento_Horario",
                "[HoraFim] > [HoraInicio]");
        });

        // Chave primária
        builder.HasKey(h => h.Id);

        builder.Property(h => h.Id)
            .ValueGeneratedOnAdd();

        // Unidade
        builder.Property(h => h.UnidadeId)
            .IsRequired();

        builder.HasOne(h => h.Unidade)
            .WithMany(u => u.HorariosFuncionamento)
            .HasForeignKey(h => h.UnidadeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Dia da semana: 0 a 6
        builder.Property(h => h.DiaSemana)
            .HasColumnType("tinyint")
            .IsRequired();

        // Horários
        builder.Property(h => h.HoraInicio)
            .HasColumnType("time(0)")
            .IsRequired();

        builder.Property(h => h.HoraFim)
            .HasColumnType("time(0)")
            .IsRequired();

        // Controle
        builder.Property(h => h.Ativo)
            .HasDefaultValue(true)
            .IsRequired();

        // Índice
        builder.HasIndex(h => new
        {
            h.UnidadeId,
            h.DiaSemana,
            h.Ativo
        })
            .HasDatabaseName(
                "IX_HorarioFuncionamento_Unidade_Dia_Ativo");
    }
}
