
namespace Agendamento.Domain.Entities.Empresas;

public class AuditoriaEmpresa
{
    public Guid Id { get; set; }

    public Guid EmpresaId { get; set; }

    public Guid? UsuarioId { get; set; }

    public string CampoAlterado { get; set; } = string.Empty;

    public string? ValorAnterior { get; set; }

    public string? ValorNovo { get; set; }

    public DateTime DataAlteracao { get; set; }

    // Relacionamentos
    public Empresa Empresa { get; set; } = null!;
}
