﻿using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Roles.Maps
{
    public class RolProfile : Profile
    {
        public RolProfile() {
            CreateMap<Rol, RolDto>();
        }
    }
}
