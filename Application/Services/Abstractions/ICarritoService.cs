using Application.Dtos.Carritos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface ICarritoService
    {
                Task<CarritoDto?> BucarProductosCarrito(int id);
                Task<IList<CarritoDto>> ListarCarrito();
                Task<CarritoDto> CrearCarrito(CarritoFormDto entity);
                Task<CarritoDto?> EliminarProductoDelCarrito(int id);


    }
}
