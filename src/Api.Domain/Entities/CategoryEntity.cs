using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public CategoryEntity()
        {
        }
        public string Title { get; set; }
        public List<ProductCategoryEntity> ProductCategory { get; set; }
    }
}
