using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Category;

namespace Api.Domain.Interfaces.Services.Category
{
    public interface ICategoryService
    {
        Task<CategoryDto> Get(Guid id);
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDtoCreateResult> Post(CategoryDtoCreate product);
        Task<CategoryDtoUpdateResult> Put(CategoryDtoUpdate product, Guid id);
        Task<bool> Delete(Guid id);
    }
}
