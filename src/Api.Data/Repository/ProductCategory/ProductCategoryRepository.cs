using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository.ProductCategory
{
    public class ProductCategoryRepository : BaseRepository<ProductCategoryEntity>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ApiContext context) : base(context)
        {

        }

        public async Task<bool> DeleteByIdProductAsync(Guid idProduct)
        {
            try
            {
                var result = await _dataset.Where(p => p.IdProduct.Equals(idProduct)).ToListAsync();

                if (result == null)
                    return false;

                _dataset.RemoveRange(result);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductCategoryEntity>> SelectByIdProductAsync(Guid idProduct)
        {
            try
            {

                var result = await _dataset.Where(p => p.IdProduct.Equals(idProduct)).Include(p => p.Category).ToListAsync();
                var result2 = await _dataset.Where(p => p.IdProduct.Equals(idProduct)).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
