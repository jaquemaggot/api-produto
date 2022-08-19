using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Category;

namespace Api.Domain.Interfaces.Services.ProductCategory
{
    public interface IProductCategoryService
    {
        Task InsertProductCategoriesAsync(Guid idProduct, List<Guid> idCategories);
        Task<bool> DeleteByIdProductAsync(Guid idProduct);
        Task<List<CategoryDto>> SelectCategoriesByIdProductAsync(Guid idProduct);
    }
}
