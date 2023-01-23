
namespace Domain
{
    public class Carrito
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public int Estado { get; set; } = 1;

        public virtual Usuario Usuario { get; set; }
        public virtual Producto Producto { get; set; }

        public virtual IList<Usuario> Usuarios { get; set; }

        public virtual IList<Producto> Productos { get; set; }

    }
}
