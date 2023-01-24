using Application.Dtos.Categorias;
using Application.Dtos.Usuarios;

namespace Application.Dtos.Productos
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; }
        public int Flag { get; set; }
        public DateTime FechaRegistro { get; set; }
        public virtual CategoriaDto Categoria { get; set; }
    }
}
