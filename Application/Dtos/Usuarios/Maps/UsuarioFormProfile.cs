﻿using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Usuarios.Maps
{
    public class UsuarioFormProfile : Profile
    {
        public UsuarioFormProfile() 
        {
            CreateMap<Usuario, UsuarioFormDto>().ReverseMap();
        }

    }
}
