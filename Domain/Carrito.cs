
namespace Domain
{
    public class Carrito
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int UsurioId { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public int Estado { get; set; } = 1;

        public virtual Producto? Producto { get; set; }
        public virtual Usuario? Usuario { get; set; }   


    }
}
