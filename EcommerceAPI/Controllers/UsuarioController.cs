using Application.Dtos.Productos;
using Application.Dtos.Usuarios;
using Application.Services.Abstractions;
using Application.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService= usuarioService;
        }

        [AllowAnonymous]
        [HttpPost("Generate/Token")]
        public async Task<IActionResult> GenerateToken([FromBody] TokenRequestDto requestDto)
        {
            var response = await _usuarioService.GenerarToken(requestDto);
            return response.IsSuccess ? Ok(response) : BadRequest(response);

        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UsuarioFormDto requestDto)
        {
            var response = await _usuarioService.Register(requestDto);
            return Ok(response);
        }
        [HttpGet("ListarUsurario")]
        public async Task<IEnumerable<UsuarioDto>> Get()
           => await _usuarioService.ListaUsuarios();
    }
}
