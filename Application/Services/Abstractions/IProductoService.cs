using Application.Dtos.Productos;
using Utils.Static;

namespace Application.Services.Abstractions
{
    public interface IProductoService
    {
        Task<ProductoDto?> BuscarProducto(int id);
        Task<IList<ProductoDto>> ListaProductos();
        Task<ProductoDto?> EditProducto(int id, ProductoFormDto entity);
        Task<ProductoDto> GenerarProducto(ProductoFormDto entity);
        Task<ProductoDto?> EliminarProducto(int id);
        Task<IList<ProductoDto>> ListarProductoAsync(PeticionFiltroDto<ProductoPeticionDto> peticion);
    }
}
