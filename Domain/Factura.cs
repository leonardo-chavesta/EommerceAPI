namespace Domain
{
    public class Factura
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int NumeroFactura { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal Impuestos { get; set; }
        public DateTime FechaEmision { get; set; } = DateTime.Now;
    }
}
