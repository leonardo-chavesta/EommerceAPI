using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.ModelMaps
{
    public class PedidoMaps : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("PEDIDO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.IdUsuario).HasColumnName("ID_USUARIO");
            builder.Property(x => x.IdProducto).HasColumnName("ID_PRODUCTO");
            builder.Property(x => x.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(x => x.Flag).HasColumnName("FLAG");
            builder.Property(x => x.Estado).HasColumnName("ESTADO");
        }
    }
}
