using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Category;
using Api.Domain.Entities;
using Api.Domain.Exceptions;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Category;
using Api.Domain.Model;
using AutoMapper;
using FluentValidation;

namespace Api.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private IRepository<CategoryEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryEntity> _validator;
        public CategoryService(IRepository<CategoryEntity> repository, IMapper mapper, IValidator<CategoryEntity> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            var resultDto = _mapper.Map<CategoryDto>(entity);
            if (resultDto is null)
            {
                throw new NotFoundException($"Categoria {id} inexistente");
            }
            else
            {
                return await _repository.DeleteAsync(id);
            }
        }

        public async Task<CategoryDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            var result = _mapper.Map<CategoryDto>(entity);
            if (result is null)
            {
                throw new NotFoundException($"Categoria {id} inexistente");
            }
            else
            {
                return _mapper.Map<CategoryDto>(entity);
            }

        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(listEntity);

        }

        public async Task<CategoryDtoCreateResult> Post(CategoryDtoCreate category)
        {
            var model = _mapper.Map<CategoryModel>(category);
            var entity = _mapper.Map<CategoryEntity>(model);
            var validationResult = await _validator.ValidateAsync(entity);

            if (validationResult.IsValid)
            {
                var result = await _repository.InsertAsync(entity);
                return _mapper.Map<CategoryDtoCreateResult>(result);
            }
            throw new FluentValidationException(validationResult);
        }

        public async Task<CategoryDtoUpdateResult> Put(CategoryDtoUpdate category, Guid id)
        {
            var model = _mapper.Map<CategoryModel>(category);
            model.Id = id;
            var entity = _mapper.Map<CategoryEntity>(model);
            var categoryExists = await _repository.SelectAsync(id);
            if (categoryExists is null)
            {
                throw new NotFoundException($"Categoria {id} inexistente");
            }
            if (entity != null)
            {
                var validationResult = await _validator.ValidateAsync(entity);
                if (validationResult.IsValid)
                {
                    var result = await _repository.UpdateAsync(entity);
                    return _mapper.Map<CategoryDtoUpdateResult>(result);
                }
                throw new FluentValidationException(validationResult);
            }
            else
            {
                return null;
            }
        }
    }
}
