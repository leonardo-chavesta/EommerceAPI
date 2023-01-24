using Application.Dtos.Carritos;

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
