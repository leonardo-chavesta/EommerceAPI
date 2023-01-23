using AutoMapper;
using Domain;

namespace Application.Dtos.Productos.Maps
{
    public class ProductoFormDto : Profile
    {
        public ProductoFormDto()
        { 
            CreateMap<Producto, ProductoFormDto>().ReverseMap();
        }

    }
}
