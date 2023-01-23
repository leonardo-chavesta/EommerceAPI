using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.ModelMaps
{
    public class CarritoMaps : IEntityTypeConfiguration<Carrito>
    {
        public void Configure(EntityTypeBuilder<Carrito> builder)
        {
            builder.ToTable("CARRITO");
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).HasColumnName("ID");
            builder.Property(x=> x.ProductoId).HasColumnName("ID_PRODUCTO");
            builder.Property(x=> x.UsurioId).HasColumnName("ID_USUARIO");
            builder.Property(x=> x.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(x=> x.Estado).HasColumnName("ESTADO");

            //builder.HasOne

        }
    }
}
