using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using order.service.domain.Interfaces.Repositories;
using order.service.efcore.Context;
using order.service.efcore.Rpositories;
using System;

namespace order.service.efcore.Bootstrapper;


public record EntityBootStrapperOptions(
    bool ApplyMigrations = false,
    bool AddRepositories = false
);

public static class EFCoreBootstrapper
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<OrderContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SQLServerConnection"));
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        return services;
    }

    //Apply migrations
    public static void ApplyMigrations(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<OrderContext>();

        var logger = scope.ServiceProvider.GetRequiredService<ILogger<OrderContext>>();

        try
        {
            logger.LogInformation("Applying migrations...");
            context.Database.Migrate();
            logger.LogInformation("Migrations applied successfully");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while applying migrations");
        }
        finally
        {
            context.Dispose();
        }
    }
}
