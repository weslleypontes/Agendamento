
using Agendamento.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Infrastructure.Data;

public class AppDbContext : IdentityUserContext<UsuarioIdentity, Guid>
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UsuarioIdentity>(entity =>
        {
            entity.ToTable("Usuario");

            entity.Property(u => u.Nome)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(u => u.Ativo)
                .HasDefaultValue(true);

            entity.Property(u => u.DataCadastro)
                .HasColumnType("datetime2(0)")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            entity.Property(u => u.UltimoAcesso)
                .HasColumnType("datetime2(0)");

            entity.HasIndex(u => u.NormalizedEmail)
                .IsUnique()
                .HasDatabaseName("UX_Usuario_NormalizedEmail")
                .HasFilter("[NormalizedEmail] IS NOT NULL");
        });
    }
}
