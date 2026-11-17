using Microsoft.AspNetCore.Identity;

namespace Agendamento.Infrastructure.Identity;

public class UsuarioIdentity : IdentityUser<Guid>
{
    public string Nome { get; set; } = string.Empty;

    public bool Ativo { get; set; } = true;

    public DateTime DataCadastro { get; set; }

    public DateTime? UltimoAcesso { get; set; }
}
