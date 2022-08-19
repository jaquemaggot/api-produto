using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Product;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Product;
using Api.Domain.Interfaces.Services.ProductCategory;
using Api.Domain.Models;
using AutoMapper;
using Api.Domain.Interfaces.Services.Category;
using Api.Domain.Exceptions;
using FluentValidation;

namespace Api.Service.Services
{
    public class ProductService : IProductService
    {
        private IRepository<ProductEntity> _repository;

        private readonly IMapper _mapper;
        private readonly IProductCategoryService _productCategoryService;
        private readonly ICategoryService _categoryService;
        private readonly IValidator<ProductEntity> _validator;

        public ProductService(IRepository<ProductEntity> repository, IMapper mapper, IProductCategoryService productCategoryService, ICategoryService categoryservice, IValidator<ProductEntity> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _productCategoryService = productCategoryService;
            _categoryService = categoryservice;
            _validator = validator;
        }
        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            var result = _mapper.Map<ProductDto>(entity);
            if (result == null)
            {
                throw new NotFoundException($"Produto {id} inexistente");
            }
            else
            {
                return await _repository.DeleteAsync(id);
            }
        }

        public async Task<ProductDto> Get(Guid id)
        {

            var entity = await _repository.SelectAsync(id);
            var result = _mapper.Map<ProductDto>(entity);
            if (result == null)
            {
                throw new NotFoundException($"Produto {id} inexistente");
            }
            else
            {
                result.Categories = await _productCategoryService.SelectCategoriesByIdProductAsync(result.Id);
                return result;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            var result = _mapper.Map<IEnumerable<ProductDto>>(listEntity);
            foreach (var item in result)
            {
                item.Categories = await _productCategoryService.SelectCategoriesByIdProductAsync(item.Id);
            }

            return result;
        }

        public async Task<ProductDtoCreateResult> Post(ProductDtoCreate product)
        {

            foreach (var item in product.CategoriesId)
            {
                var category = await _categoryService.Get(item);
                if (category is null)
                {
                    throw new NotFoundException($"Categoria {item} inexistente");
                }
            }

            var model = _mapper.Map<ProductModel>(product);
            var entity = _mapper.Map<ProductEntity>(model);
            var validationResult = await _validator.ValidateAsync(entity);
            if (validationResult.IsValid)
            {
                var result = await _repository.InsertAsync(entity);
                await _productCategoryService.InsertProductCategoriesAsync(result.Id, product.CategoriesId);
                var resultDto = _mapper.Map<ProductDtoCreateResult>(result);
                resultDto.Categories = await _productCategoryService.SelectCategoriesByIdProductAsync(result.Id);
                return resultDto;
            }
            throw new FluentValidationException(validationResult);
        }

        public async Task<ProductDtoUpdateResult> Put(ProductDtoUpdate product, Guid id)
        {
            foreach (var item in product.CategoriesId)
            {
                var category = await _categoryService.Get(item);
                if (category is null)
                {
                    throw new NotFoundException($"Categoria {item} inexistente");
                }
            }

            var model = _mapper.Map<ProductModel>(product);
            model.Id = id;
            var entity = _mapper.Map<ProductEntity>(model);
            var productExists = await _repository.SelectAsync(id);
            if (productExists is null)
            {
                throw new NotFoundException($"Produto {id} inexistente");

            }
            else
            {
                var validationResult = await _validator.ValidateAsync(entity);
                if (validationResult.IsValid)
                {
                    var result = await _repository.UpdateAsync(entity);
                    await _productCategoryService.DeleteByIdProductAsync(result.Id);
                    await _productCategoryService.InsertProductCategoriesAsync(result.Id, product.CategoriesId);
                    var resultDto = _mapper.Map<ProductDtoUpdateResult>(result);
                    resultDto.Categories = await _productCategoryService.SelectCategoriesByIdProductAsync(result.Id);
                    return resultDto;
                }
                throw new FluentValidationException(validationResult);
            }

        }
    }
}
