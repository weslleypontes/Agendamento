
namespace Agendamento.Domain.Entities.Profissionais;

public class DisponibilidadeProfissional
{
    public Guid Id { get; set; }

    public Guid EmpresaId { get; set; }

    public Guid ProfissionalUnidadeId { get; set; }

    public byte DiaSemana { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFim { get; set; }

    public bool Ativo { get; set; } = true;

    // Relacionamento
    public ProfissionalUnidade ProfissionalUnidade { get; set; }
        = null!;
}
