using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Usuarios.Maps
{
    public class TokenFormProfile : Profile
    {
        public TokenFormProfile()
        {
            CreateMap<UsuarioFormDto, Usuario>();
        }
    }
}
