using Application.Dtos.Usuarios;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infraestructure.Repositories.Abstractions;

namespace Application.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository) 
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDto?> Autentifica(UsuarioFormLoginDto admin)
        {
            var dto = _mapper.Map<Usuario>(admin);
            var response = await _usuarioRepository.Autentifica(dto);

           return _mapper.Map<UsuarioDto>(response);
        }
    }
}
