using AutoMapper;
using Domain;

namespace Application.Dtos.Carritos.Maps
{
    public class CarritoFormProfile : Profile
    {
        public CarritoFormProfile()
        {
            CreateMap<Carrito, CarritoFormDto>().ReverseMap();
        }

    }
}
