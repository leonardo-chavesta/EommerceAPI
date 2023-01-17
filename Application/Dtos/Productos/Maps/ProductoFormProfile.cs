using AutoMapper;
using Domain;

namespace Application.Dtos.Productos.Maps
{
    public class ProductoFormProfile : Profile
    {
        public ProductoFormProfile()
        { 
            CreateMap<Producto, ProductoFormDto>().ReverseMap();
        }

    }
}
