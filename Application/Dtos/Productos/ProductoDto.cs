using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Productos
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; }
        public int Flag { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
