using order.service.domain.Interfaces.Repositories;
using order.service.domain.Repositories;

namespace order.service.api.Ioc
{
    public static class RepositoriesStartup
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IItemRepository, ItemRepository>();
        }
    }
}
