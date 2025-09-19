using Core.Domain.Repositories;
using Core.Drivers;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

namespace E.Final.Tests;

public class Dependencies
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        services.AddScoped<MemoryProductRepository>();
        services.AddScoped<IProductRepository>(sp => sp.GetRequiredService<MemoryProductRepository>());
        services.AddScoped<IRepository>(sp => sp.GetRequiredService<MemoryProductRepository>());

        services.AddScoped<ShopDriver>();

        return services;
    }
}