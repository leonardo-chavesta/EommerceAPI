using Domain;
namespace Infraestructure.Repositories.Abstractions
{
    public interface IProductoRepository
    {
        Task<IList<Producto>> ListaProductos();
        Task<Producto?> BuscarProducto(int id);
        Task<Producto> GenerarProducto(Producto entity);
        Task<Producto?> EditProducto(int id, Producto entity);
        Task<Producto?> EliminarProducto(int id);
    }
}
