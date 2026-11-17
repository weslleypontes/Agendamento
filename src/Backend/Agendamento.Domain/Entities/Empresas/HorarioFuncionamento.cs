
namespace Agendamento.Domain.Entities.Empresas;

public class HorarioFuncionamento
{
    public Guid Id { get; set; }

    public Guid UnidadeId { get; set; }

    public byte DiaSemana { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFim { get; set; }

    public bool Ativo { get; set; } = true;

    // Relacionamento
    public Unidade Unidade { get; set; } = null!;
}
