namespace Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public int Flag { get; set; }
        public int Estado { get; set; } = 1;
    }
}
