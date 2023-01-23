using Application.Dtos.Usuarios;
using Application.Services.Abstractions;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Autentica")]
        public async Task<Results<NotFound, Ok<UsuarioDto>>> Post([FromBody] UsuarioFormLoginDto admin)
        {
            var adm = await _usuarioService.Autentifica(admin);
            if (adm == null)
            {
                return TypedResults.NotFound();
            }


            return TypedResults.Ok(adm);
        }
    }
}
