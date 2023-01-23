using AutoMapper;
using Domain;

namespace Application.Dtos.Usuarios.Maps
{
    public class UsuarioFormLoginDto : Profile
    {
        public UsuarioFormLoginDto() 
        {
            CreateMap<Usuario, UsuarioFormLoginDto>().ReverseMap();
        }
    }
}
