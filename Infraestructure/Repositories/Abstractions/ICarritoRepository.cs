using Domain;

namespace Infraestructure.Repositories.Abstractions
{
    public interface ICarritoRepository
    {
        Task<IList<Carrito>> ListarCarrito();
        Task<Carrito?> BucarProductosCarrito(int id);
        Task<Carrito> CrearCarrito(Carrito entity);
        Task<Carrito?> EliminarProductoDelCarrito(int id);

        Task<IList<Carrito?>> BuscarComprasXUsuario(int idUsuario);
    }
}
