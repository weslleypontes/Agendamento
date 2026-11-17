
namespace Agendamento.Domain.Entities.Empresas;

public class ExcecaoFuncionamento
{
    public Guid Id { get; set; }

    public Guid UnidadeId { get; set; }

    public DateOnly DataInicio { get; set; }

    public DateOnly DataFim { get; set; }

    public byte Tipo { get; set; }

    public string? Motivo { get; set; }

    // Relacionamentos
    public Unidade Unidade { get; set; } = null!;

    public ICollection<PeriodoFuncionamentoExcepcional>
        Periodos
    { get; set; }
        = new List<PeriodoFuncionamentoExcepcional>();
}
