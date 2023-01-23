using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Abstractions
{
    public interface ICarritoRepository
    {
        Task<IList<Carrito>> ListarCarrito();
        Task<Carrito?> BucarProductosCarrito(int id);
        Task<Carrito> CrearCarrito(Carrito entity);
        Task<Carrito?> EliminarProductoDelCarrito(int id); 
    }
}
