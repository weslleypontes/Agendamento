
namespace Agendamento.Domain.Entities.Empresas;

public class ConfiguracaoAgendamento
{
    public Guid Id { get; set; }

    public Guid UnidadeId { get; set; }

    public int AntecedenciaMinimaHoras { get; set; } = 0;

    public int AntecedenciaMaximaDias { get; set; }

    public int IntervaloEntreAtendimentosMinutos { get; set; } = 0;

    public bool PermiteAgendamentoMesmoDia { get; set; } = true;

    public int PrazoCancelamentoHoras { get; set; } = 0;

    public bool PermiteReagendamento { get; set; } = true;

    public int PrazoReagendamentoHoras { get; set; } = 0;

    public bool ConfirmacaoAutomatica { get; set; }

    // Relacionamento
    public Unidade Unidade { get; set; } = null!;
}
