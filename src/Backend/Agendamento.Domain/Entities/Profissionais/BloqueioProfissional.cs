
namespace Agendamento.Domain.Entities.Profissionais;

public class BloqueioProfissional
{
    public Guid Id { get; set; }

    public Guid EmpresaId { get; set; }

    public Guid ProfissionalUnidadeId { get; set; }

    public DateTime DataHoraInicio { get; set; }

    public DateTime DataHoraFim { get; set; }

    public string? Motivo { get; set; }

    public bool Ativo { get; set; } = true;

    public DateTime DataCadastro { get; set; }

    // Relacionamento
    public ProfissionalUnidade ProfissionalUnidade { get; set; }
        = null!;
}
