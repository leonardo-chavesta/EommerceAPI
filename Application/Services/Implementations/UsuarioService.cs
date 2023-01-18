using Application.Base;
using Application.Dtos.Usuarios;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infraestructure.Repositories.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utils.Static;
using BC = BCrypt.Net.BCrypt;

namespace Application.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository, IConfiguration configuration) 
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        private string GenerateToken(Usuario account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, account.Correo!),
                new Claim(JwtRegisteredClaimNames.FamilyName, account.Nombre!),
                new Claim(JwtRegisteredClaimNames.GivenName, account.Correo!),
                new Claim(JwtRegisteredClaimNames.UniqueName, account.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, Guid.NewGuid().ToString(), ClaimValueTypes.Integer64)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:Expires"])),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       public async Task<BaseResponse<object>> GenerarToken(TokenRequestDto requestDto)
        {
            var response = new BaseResponse<object> ();
            var account = await _usuarioRepository.AcountCorreo(requestDto.Correo!);
            
            if (account is not null)
            {
                if (BC.Verify(requestDto.Contrasenia, account.Contrasenia))
                {
                    response.IsSuccess = true;
                    response.Data = GenerateToken(account);
                    response.Message = Message.MESSAGE_TOKEN;
                    return response;

                }
                else
                {

                    response.IsSuccess = true;
                    response.Message = Message.MESSAGE_TOKEN_ERROR;
                }

            }
            else
            {

                response.IsSuccess = true;
                response.Message = Message.MESSAGE_TOKEN_ERROR;
            }
            return response;
        }

        
    }
}
