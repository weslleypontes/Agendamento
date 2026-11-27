
using Agendamento.Domain.Entities.Empresas;

namespace Agendamento.Domain.Entities.Profissionais;

public class Profissional
{
    public Guid Id { get; set; }

    public Guid EmpresaId { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public bool Ativo { get; set; } = true;

    public DateTime DataCadastro { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    // Relacionamento com Empresa
    public Empresa Empresa { get; set; } = null!;

    // Relacionamentos com outros módulos
    public ICollection<ProfissionalUnidade> Unidades
    { get; set; } = new List<ProfissionalUnidade>();

    public ICollection<ProfissionalServico> Servicos
    { get; set; } = new List<ProfissionalServico>();

    public ICollection<ProfissionalUsuario> Usuarios
    { get; set; } = new List<ProfissionalUsuario>();
}
