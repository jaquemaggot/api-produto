using Api.Domain.Entities;
using Api.Domain.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public static class ConfigureValidator
    {
        public static void ConfigureDependenciesValidator(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IValidator<CategoryEntity>, CategoryValidator>();
            serviceCollection.AddScoped<IValidator<ProductEntity>, ProductValidator>();
        }
    }
}
