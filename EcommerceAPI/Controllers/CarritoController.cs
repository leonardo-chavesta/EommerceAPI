using Application.Dtos.Carritos;
using Application.Services.Abstractions;
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



    }
}
