using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.ModelMaps
{
    public class FacturaMaps : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("FACTURA");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x=> x.IdPedido).HasColumnName("ID_PEDIDO");
            builder.Property(x=> x.NumeroFactura).HasColumnName("NUMERO_FACTURA");
            builder.Property(x=> x.FechaEmision).HasColumnName("FECHA_EMISION");
            builder.Property(x=> x.SubTotal).HasColumnName("SUBTOTAL");
            builder.Property(x => x.Impuestos).HasColumnName("IMPUESTOS");
            builder.Property(x=> x.Total).HasColumnName("TOTAL");
        }
    }
}
