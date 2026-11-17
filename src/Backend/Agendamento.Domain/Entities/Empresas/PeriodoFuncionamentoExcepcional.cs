
namespace Agendamento.Domain.Entities.Empresas;

public class PeriodoFuncionamentoExcepcional
{
    public Guid Id { get; set; }

    public Guid ExcecaoFuncionamentoId { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFim { get; set; }

    // Relacionamento
    public ExcecaoFuncionamento ExcecaoFuncionamento
    { get; set; } = null!;
}
