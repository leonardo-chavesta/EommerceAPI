using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Carritos.Maps
{
    public class CarritoProfile : Profile
    {
        public CarritoProfile()
        {
            CreateMap<Carrito, CarritoDto>();
        }
    }
}
