using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repository
{
    public interface IProductCategoryRepository : IRepository<ProductCategoryEntity>
    {
        Task<bool> DeleteByIdProductAsync(Guid idProduct);
        Task<List<ProductCategoryEntity>> SelectByIdProductAsync(Guid idProduct);
    }
}
