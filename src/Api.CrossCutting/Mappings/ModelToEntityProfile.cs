using Api.Domain.Entities;
using Api.Domain.Model;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<ProductEntity, ProductModel>()
                .ReverseMap();
            CreateMap<CategoryEntity, CategoryModel>()
                .ReverseMap();
        }
    }
}
