using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.ModelMaps
{
    public class ImagenMaps : IEntityTypeConfiguration<Imagen>
    {
        public void Configure(EntityTypeBuilder<Imagen> builder)
        {
            builder.ToTable("IMAGEN");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descripcion).HasColumnName("DESCRIPCION");
            builder.Property(x => x.Url).HasColumnName("URL");
            builder.Property(x => x.Estado).HasColumnName("ESTADO");
            builder.Property(x => x.FechaCreacion).HasColumnName("FECHA_CREACION");
        }
    }
}
