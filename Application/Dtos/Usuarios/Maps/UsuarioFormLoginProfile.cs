using AutoMapper;
using Domain;

namespace Application.Dtos.Usuarios.Maps
{
    public class UsuarioFormLoginProfile : Profile
    {
        public UsuarioFormLoginProfile() 
        {
            CreateMap<Usuario, UsuarioFormLoginProfile>().ReverseMap();
        }
    }
}
