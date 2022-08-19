using Api.Domain.Dtos.Category;
using Api.Domain.Dtos.Product;
using Api.Domain.Model;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<ProductModel, ProductDto>()
                .ReverseMap();
            CreateMap<ProductModel, ProductDtoCreate>()
                .ReverseMap();
            CreateMap<ProductModel, ProductDtoUpdate>()
                .ReverseMap();
            CreateMap<CategoryModel, CategoryDto>()
                .ReverseMap();
            CreateMap<CategoryModel, CategoryDtoCreate>()
                .ReverseMap();
            CreateMap<CategoryModel, CategoryDtoUpdate>()
                .ReverseMap();
        }
    }
}
