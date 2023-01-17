using Application.Dtos.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IProductoService
    {
        Task<ProductoDto?> BuscarProducto(int id);
        Task<IList<ProductoDto>> ListaProductos();
        Task<ProductoDto?> EditProducto(int id, ProductoFormDto entity);
        Task<ProductoDto> GenerarProducto(ProductoFormDto entity);
        Task<ProductoDto?> EliminarProducto(int id);
    }
}
