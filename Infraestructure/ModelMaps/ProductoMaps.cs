using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.ModelMaps
{
    public class ProductoMaps : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("PRODUCTOS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Nombre).HasColumnName("NOMBRE");
            builder.Property(x => x.Descripcion).HasColumnName("DESCRIPCION");
            builder.Property(x => x.Precio).HasColumnName("PRECIO");
            builder.Property(x => x.Estado).HasColumnName("ESTADO");
            builder.Property(x => x.IdCategoria).HasColumnName("ID_CATEGORIA");
            builder.Property(x => x.IdUsuario).HasColumnName("ID_USUARIO");
            builder.Property(x => x.FechaRegistro).HasColumnName("FECHA_REGISTRO");

            builder.HasOne(t => t.Categoria).WithMany(t => t.Productos).HasForeignKey(t => t.IdCategoria);
            builder.HasOne(t => t.Usuario).WithMany(t => t.Productos).HasForeignKey(t => t.IdUsuario);
        }
    }
}
