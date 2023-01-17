using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.ModelMaps
{
    public class ProductoMaps : IEntityTypeConfiguration<Productos>
    {
        public void Configure(EntityTypeBuilder<Productos> builder)
        {
            builder.ToTable("PRODUTOS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Nombre).HasColumnName("NOMBRE");
            builder.Property(x => x.Descripcion).HasColumnName("DECRIPCION");
            builder.Property(x => x.Precio).HasColumnName("PRECIO");
            builder.Property(x => x.Estado).HasColumnName("ESTADO");
            builder.Property(x => x.IdCategoria).HasColumnName("ID_CATEGORIA");
            builder.Property(x => x.FechaRegistro).HasColumnName("FECHA_REGISTRO");
        }
    }
}
