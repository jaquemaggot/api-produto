using System;

namespace Api.Domain.Entities
{
    public class ProductCategoryEntity : BaseEntity
    {

        public Guid IdProduct { get; set; }
        public Guid IdCategory { get; set; }
        public ProductEntity Product { get; set; }
        public CategoryEntity Category { get; set; }

        public ProductCategoryEntity()
        {

        }

        public ProductCategoryEntity(Guid idProduct, Guid idCategory)
        {
            IdProduct = idProduct;
            IdCategory = idCategory;
        }
    }
}
