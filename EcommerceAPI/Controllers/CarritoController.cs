using Application.Dtos.Carritos;
using Application.Dtos.Productos;
using Application.Services.Abstractions;
using Application.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : Controller
    {
        private readonly ICarritoService _carritoService;

        public CarritoController(ICarritoService carritoService)
        {
            _carritoService = carritoService;
        }
        [HttpGet("Listar")]
        public async Task<IEnumerable<CarritoDto>> Get()
            => await _carritoService.ListarCarrito();
        
        
        [HttpPost("CrearCarrito")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarritoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<CarritoDto>>> Post([FromBody] CarritoFormDto request)
        {
            var response = await _carritoService.CrearCarrito(request);
            if (response == null) return TypedResults.BadRequest();
            return TypedResults.Ok(response);
        }

        [HttpDelete("EliminarDelCarrito/{id}")]
        public async Task<Results<NotFound, Ok<CarritoDto>>> Delete(int id)
        {
            var response = await _carritoService.EliminarProductoDelCarrito(id);
            if(response == null) TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("BuscarComprasXUsuario/{idUsuario}")]
        public async Task<IEnumerable<CarritoDto>> BuscarComprasXUsuario(int idUsuario)
           => await _carritoService.BuscarComprasXUsuario(idUsuario);


    }
}
