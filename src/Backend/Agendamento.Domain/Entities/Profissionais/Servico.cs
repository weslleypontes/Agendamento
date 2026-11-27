
using Agendamento.Domain.Entities.Empresas;

namespace Agendamento.Domain.Entities.Profissionais;

public class Servico
{
    public Guid Id { get; set; }

    public Guid EmpresaId { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string? Descricao { get; set; }

    public decimal PrecoPadrao { get; set; }

    public int DuracaoPadraoMinutos { get; set; }

    public bool Ativo { get; set; } = true;

    public DateTime DataCadastro { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    // Relacionamento com Empresa
    public Empresa Empresa { get; set; } = null!;

    // Profissionais habilitados para executar o serviço
    public ICollection<ProfissionalServico> Profissionais
    { get; set; } = new List<ProfissionalServico>();
}
