using Application.Dtos.Carritos;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infraestructure.Repositories.Abstractions;

namespace Application.Services.Implementations
{
    public class CarritoService : ICarritoService
    {
        private readonly IMapper _mapper;
        private readonly ICarritoRepository _carritoRepository;

        public CarritoService(ICarritoRepository carritoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _carritoRepository = carritoRepository;
        }

        public async Task<CarritoDto?> BucarProductosCarrito(int id)
        {
            var response = await _carritoRepository.BucarProductosCarrito(id);
            return _mapper.Map<CarritoDto?>(response);
        }

        public async Task<CarritoDto> CrearCarrito(CarritoFormDto entity)
        {
            var dto = _mapper.Map<Carrito>(entity);
            var response = await _carritoRepository.CrearCarrito(dto);
            return _mapper.Map<CarritoDto>(response);
        }

        public async Task<CarritoDto?> EliminarProductoDelCarrito(int id)
        {
            var response = await _carritoRepository.EliminarProductoDelCarrito(id);
            return _mapper.Map<CarritoDto>(response);
        }

        public async Task<IList<CarritoDto>> ListarCarrito()
        {
              var response = await _carritoRepository.ListarCarrito();

             return _mapper.Map<IList<CarritoDto>>(response);
             
        }
    }
}
