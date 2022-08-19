using Api.Domain.Interfaces.Services.Category;
using Api.Domain.Interfaces.Services.Product;
using Api.Domain.Interfaces.Services.ProductCategory;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IProductService, ProductService>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<IProductCategoryService, ProductCategoryService>();
        }
    }
}
