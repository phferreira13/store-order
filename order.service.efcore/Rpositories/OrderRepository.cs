using order.service.domain.Interfaces.Repositories;
using order.service.domain.Models;
using order.service.efcore.Context;

namespace order.service.efcore.Rpositories;
public class OrderRepository : BaseRepository, IOrderRepository
{
    public OrderRepository(OrderContext context) : base(context)
    {
    }

    public async Task<Order> AddAsync(Order order)
    {
        return await base.Add(order);
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        return await base.Update(order);
    }

    public async Task<Order> DeleteAsync(int orderId)
    {
        var order = await base.GetById<Order>(orderId)
            ?? throw new Exception("Order not found");
        return await base.Delete(order);
    }

    public async Task<Order?> GetByIdAsync(int orderId)
    {
        return await base.GetById<Order>(orderId);
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await base.GetAll<Order>();
    }
}
