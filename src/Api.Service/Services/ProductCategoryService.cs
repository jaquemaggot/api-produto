using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Category;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Services.ProductCategory;
using AutoMapper;

namespace Api.Service.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }
        public async Task<bool> DeleteByIdProductAsync(Guid idProduct)
        {
            return await _productCategoryRepository.DeleteByIdProductAsync(idProduct);
        }

        public async Task InsertProductCategoriesAsync(Guid idProduct, List<Guid> idCategories)
        {
            foreach (var item in idCategories)
            {
                var productCategoryEntity = new ProductCategoryEntity(idProduct, item);
                await _productCategoryRepository.InsertAsync(productCategoryEntity);
            }
        }

        public async Task<List<CategoryDto>> SelectCategoriesByIdProductAsync(Guid idProduct)
        {
            var productCategories = await _productCategoryRepository.SelectByIdProductAsync(idProduct);
            return productCategories.Select(p => _mapper.Map<CategoryDto>(p.Category)).ToList();
        }
    }
}
