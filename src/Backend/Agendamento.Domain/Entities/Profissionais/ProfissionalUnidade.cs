
namespace Agendamento.Domain.Entities.Profissionais;

public class ProfissionalUnidade
{
    public Guid Id { get; set; }

    public Guid EmpresaId { get; set; }

    public Guid ProfissionalId { get; set; }

    public Guid UnidadeId { get; set; }

    public bool Ativo { get; set; } = true;

    public DateTime DataCadastro { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    // Relacionamentos
    public Profissional Profissional { get; set; } = null!;

    public Agendamento.Domain.Entities.Empresas.Unidade
        Unidade
    { get; set; } = null!;

    public ICollection<DisponibilidadeProfissional> Disponibilidades
    { get; set; } = new List<DisponibilidadeProfissional>();

    public ICollection<BloqueioProfissional> Bloqueios
    { get; set; } = new List<BloqueioProfissional>();
}
