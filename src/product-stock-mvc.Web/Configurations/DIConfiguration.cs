using Microsoft.AspNetCore.Mvc.DataAnnotations;
using product_stock_mvc.Business.Interfaces;
using product_stock_mvc.DataAcess.Context;
using product_stock_mvc.DataAcess.Repository;
using product_stock_mvc.Web.Extensions;

namespace product_stock_mvc.Web.Configurations
{
    public static class DIConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddTransient<ProductStockDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, CurrencyValidationAttributeAdapterProvider>();

            return services;
        }
    }
}
