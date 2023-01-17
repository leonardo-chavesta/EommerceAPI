namespace Domain
{
    public class Producto
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; } = 1;
        public int Flag { get; set; } = 1;
        public DateTime FechaRegistro { get; set;} = DateTime.Now;

    }
}
