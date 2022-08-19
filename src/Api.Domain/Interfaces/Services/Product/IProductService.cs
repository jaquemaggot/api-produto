using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Product;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Product
{
    public interface IProductService
    {
        Task<ProductDto> Get(Guid id);
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDtoCreateResult> Post(ProductDtoCreate product);
        Task<ProductDtoUpdateResult> Put(ProductDtoUpdate product, Guid id);
        Task<bool> Delete(Guid id);
    }
}
