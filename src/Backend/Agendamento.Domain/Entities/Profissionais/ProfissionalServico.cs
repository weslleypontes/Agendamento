
namespace Agendamento.Domain.Entities.Profissionais;

public class ProfissionalServico
{
    public Guid Id { get; set; }

    public Guid EmpresaId { get; set; }

    public Guid ProfissionalId { get; set; }

    public Guid ServicoId { get; set; }

    public decimal? PrecoPersonalizado { get; set; }

    public int? DuracaoPersonalizadaMinutos { get; set; }

    public bool Ativo { get; set; } = true;

    public DateTime DataCadastro { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    // Relacionamentos
    public Profissional Profissional { get; set; } = null!;

    public Servico Servico { get; set; } = null!;
}
