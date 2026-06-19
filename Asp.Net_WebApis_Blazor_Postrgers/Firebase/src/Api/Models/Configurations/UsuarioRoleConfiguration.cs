using Api.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Models.Configurations
{
    public class UsuarioRoleConfiguration : IEntityTypeConfiguration<UsuarioRole>
    {
        public void Configure(EntityTypeBuilder<UsuarioRole> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.UsuarioId });
        }
    }
}