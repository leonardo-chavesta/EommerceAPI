
namespace Domain
{
    public class Carrito
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public int Estado { get; set; } = 1;

    }
}
