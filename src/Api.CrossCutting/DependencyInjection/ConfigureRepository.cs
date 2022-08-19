using Api.Data.Repository;
using Api.Data.Repository.ProductCategory;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        }
    }
}
