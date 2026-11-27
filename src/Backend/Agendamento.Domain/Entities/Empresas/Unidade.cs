using Agendamento.Domain.Entities.Profissionais;

namespace Agendamento.Domain.Entities.Empresas;

public class Unidade
{
    public Guid Id { get; set; }

    public Guid EmpresaId { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string? Cnpj { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public string? Cep { get; set; }

    public string? Logradouro { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public string FusoHorario { get; set; } = string.Empty;

    public bool Ativa { get; set; } = true;

    public DateTime DataCadastro { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    // Relacionamento
    public Empresa Empresa { get; set; } = null!;

    public ICollection<HorarioFuncionamento> HorariosFuncionamento
    { get; set; } = new List<HorarioFuncionamento>();

    public ICollection<ExcecaoFuncionamento> ExcecoesFuncionamento
    { get; set; } = new List<ExcecaoFuncionamento>();

    public ConfiguracaoAgendamento ConfiguracaoAgendamento
    { get; set; } = null!;

    public ICollection<ProfissionalUnidade> Profissionais
    { get; set; } = new List<ProfissionalUnidade>();
}
