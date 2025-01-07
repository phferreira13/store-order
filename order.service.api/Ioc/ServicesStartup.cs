using order.service.business.Services;
using order.service.domain.Interfaces.Services;

namespace order.service.api.Ioc;

public static class ServicesStartup
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IItemService, ItemService>();
        return services;
    }
}
