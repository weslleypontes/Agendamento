
using Agendamento.Domain.Entities.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamento.Infrastructure.Configurations.Empresas;

public class PeriodoFuncionamentoExcepcionalConfiguration
    : IEntityTypeConfiguration<PeriodoFuncionamentoExcepcional>
{
    public void Configure(
        EntityTypeBuilder<PeriodoFuncionamentoExcepcional> builder)
    {
        builder.ToTable("PeriodoFuncionamentoExcepcional", table =>
        {
            table.HasCheckConstraint(
                "CK_PeriodoFuncionamentoExcepcional_Horario",
                "[HoraFim] > [HoraInicio]");
        });

        // Chave primária
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        // Exceção de funcionamento
        builder.Property(p => p.ExcecaoFuncionamentoId)
            .IsRequired();

        builder.HasOne(p => p.ExcecaoFuncionamento)
            .WithMany(e => e.Periodos)
            .HasForeignKey(p => p.ExcecaoFuncionamentoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Horários
        builder.Property(p => p.HoraInicio)
            .HasColumnType("time(0)")
            .IsRequired();

        builder.Property(p => p.HoraFim)
            .HasColumnType("time(0)")
            .IsRequired();

        // Índice
        builder.HasIndex(p => p.ExcecaoFuncionamentoId)
            .HasDatabaseName(
                "IX_PeriodoFuncionamentoExcepcional_ExcecaoId");
    }
}
