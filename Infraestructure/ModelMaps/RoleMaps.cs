using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.ModelMaps
{
    public class RoleMaps : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("ROLES");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Descripcion).HasColumnName("DESCRIPCION");
            builder.Property(x => x.Estado).HasColumnName("ESTADO");
        }
    }
}
