
namespace Agendamento.Domain.Entities.Profissionais;

public class ProfissionalUsuario
{
    public Guid Id { get; set; }

    public Guid EmpresaId { get; set; }

    public Guid ProfissionalId { get; set; }

    public Guid UsuarioId { get; set; }

    public DateTime DataCadastro { get; set; }

    // Relacionamento com Profissional
    public Profissional Profissional { get; set; } = null!;
}
