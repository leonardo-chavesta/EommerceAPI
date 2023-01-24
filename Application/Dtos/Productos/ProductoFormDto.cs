using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Productos
{
    public class ProductoFormDto
    {
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
