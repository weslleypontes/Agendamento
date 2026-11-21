
using Agendamento.Domain.Entities.Empresas;

namespace Agendamento.Domain.Entities.Clientes;

public class Cliente
{
    public Guid Id { get; set; }

    public Guid EmpresaId { get; set; }

    public string TipoPessoa { get; set; } = string.Empty;

    public string Nome { get; set; } = string.Empty;

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public string? Documento { get; set; }

    public DateOnly? DataNascimento { get; set; }

    public string? Observacoes { get; set; }

    public bool Ativo { get; set; } = true;

    public DateTime DataCadastro { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    public Empresa Empresa { get; set; } = null!;
}
