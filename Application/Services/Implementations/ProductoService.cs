using Application.Dtos.Productos;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infraestructure.Repositories.Abstractions;
using Utils.Static;

namespace Application.Services.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IMapper _mapper;
        private readonly IProductoRepository _productoRepository;
        
        public ProductoService(IMapper mapper, IProductoRepository productoRepository)
        {
            _mapper= mapper;
            _productoRepository= productoRepository;
        }

        public async Task<ProductoDto?> BuscarProducto(int id)
        {
            var response = await _productoRepository.BuscarProducto(id);
            return _mapper.Map<ProductoDto?>(response);

        }

        public async Task<ProductoDto?> EditProducto(int id, ProductoFormDto entity)
        {
            var dto = _mapper.Map<Producto>(entity);
            var response = await _productoRepository.EditProducto(id, dto);

            return _mapper.Map<ProductoDto>(response);
        }

        public async Task<ProductoDto?> EliminarProducto(int id)
        {
            var response = await _productoRepository.EliminarProducto(id);

            return _mapper.Map<ProductoDto>(response);
        }

        public async Task<ProductoDto> GenerarProducto(ProductoFormDto entity)
        {
            var dto = _mapper.Map<Producto>(entity);
            var response = await _productoRepository.GenerarProducto(dto);

            return _mapper.Map<ProductoDto>(response);
        }

        public async Task<IList<ProductoDto>> ListaProductos()
        {
            var response = await _productoRepository.ListaProductos();

            return _mapper.Map<IList<ProductoDto>>(response);
        }

        public async Task<IList<ProductoDto>> ListarProductoAsync(PeticionFiltroDto<ProductoPeticionDto> peticion)
        {
            var entidad = await _productoRepository.ListarProductoAsync(peticion.Filtro.Nombre, peticion.Filtro.Categoria);
            return _mapper.Map<IList<ProductoDto>>(entidad);
        }
    }
}
