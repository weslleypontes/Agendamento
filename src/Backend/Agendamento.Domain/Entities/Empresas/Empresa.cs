using Agendamento.Domain.Entities.Clientes;

namespace Agendamento.Domain.Entities.Empresas;

public class Empresa
{
    public Guid Id { get; set; }

    public string RazaoSocial { get; set; } = string.Empty;

    public string NomeFantasia { get; set; } = string.Empty;

    public string Cnpj { get; set; } = string.Empty;

    public string? Email { get; set; }

    public string? Telefone { get; set; }

    public bool Ativa { get; set; } = true;

    public DateTime DataCadastro { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    // Relacionamentos
    public ICollection<Unidade> Unidades { get; set; }
        = new List<Unidade>();

    public ICollection<AuditoriaEmpresa> Auditorias { get; set; }
        = new List<AuditoriaEmpresa>();

    public ICollection<Cliente> Clientes { get; set; }
    = new List<Cliente>();
}

