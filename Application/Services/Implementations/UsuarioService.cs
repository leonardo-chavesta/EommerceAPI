using Application.Base;
using Application.Dtos.Productos;
using Application.Dtos.Usuarios;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using FluentValidation;
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
            bool success = false;
            
            if (account is not null)
            {
                if (BC.Verify(requestDto.Contrasenia, account.Contrasenia))
                {
                    success = true;
                    response.IsSuccess = success;
                    response.Data = account;
                    response.Message = Message.MESSAGE_TOKEN;
                    return response;
                }
                else
                {
                    response.IsSuccess = success;
                    response.Message = Message.MESSAGE_TOKEN_ERROR;
                    return response;
                }
            }
            else
            {
                response.IsSuccess = success;
                response.Message = Message.MESSAGE_TOKEN_ERROR;
                return response;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> Register(UsuarioFormDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var account = _mapper.Map<Usuario>(requestDto);
            account.Contrasenia = BC.HashPassword(requestDto.Contrasenia);

            var correo = await _usuarioRepository.UserByCorreo(account.Correo);

            if (correo != null)
            {
                response.IsSuccess = false;
                response.Message = Message.MESSAGE_CORREO;
                return response;
            }

            response.Data = await _usuarioRepository.Register(account);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = Message.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = Message.MESSAGE_FAILED;
            }
            return response;
        }

      

        public async Task<IList<UsuarioDto>> ListaUsuarios()
        {
           var response = await _usuarioRepository.ListaUsuarios();

            return _mapper.Map<IList<UsuarioDto>>(response);

        }
    }
}
