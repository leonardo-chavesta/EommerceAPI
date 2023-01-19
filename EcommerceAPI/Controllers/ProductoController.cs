using Application.Dtos.Productos;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Utils.Static;

namespace EcommerceAPI.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductoDto>> Get()
            => await _productoService.ListaProductos();

        [HttpGet("ObtenerProducto/{id}")]
        public async Task<Results<NotFound, Ok<ProductoDto>>>Get(int id)
        {
            var response = await _productoService.BuscarProducto(id);
            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
        [HttpPost("EditarProducto/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results< NotFound,Ok<ProductoDto>>> Post(int id , [FromBody] ProductoFormDto request)
        {
            var response = await _productoService.EditProducto(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        [HttpPost("CrearProducto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<ProductoDto>>> Post([FromBody] ProductoFormDto request)
        {
            var response = await _productoService.GenerarProducto(request);
            if (response == null) return TypedResults.BadRequest();
            return TypedResults.Ok(response);
        }
        [HttpDelete("EliminarProducto/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<ProductoDto>>> Delete(int id)
        {
            var response = await _productoService.EliminarProducto(id);
            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
        [HttpPost("ListarProductoAsync/Filtro")]
        public async Task<IList<ProductoDto>> ListarProductoAsync(PeticionFiltroDto<ProductoPeticionDto> peticion)
        {
            var operacion = await _productoService.ListarProductoAsync(peticion);
            return operacion;
        }

    }
}
