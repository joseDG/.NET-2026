using Api.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Models.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(x => x.Id);
            
            builder.HasMany(x => x.Permisos)
                .WithMany()
                .UsingEntity<RolePermiso>();

            builder.HasData(Role.GetValues());
        }
    }
}