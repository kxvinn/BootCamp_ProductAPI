using Bootcamp_Domain.Interfaces;
using Bootcamp_Infraestrutura.Repository;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Context;


namespace Products.InfraService;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<ApplicationDataContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IProductRepository, ProductRepository>();


        return services;
    }
}
