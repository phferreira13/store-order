using order.service.domain.Interfaces.Repositories;
using order.service.domain.Models;
using order.service.efcore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.service.efcore.Rpositories;
public class OrderRepository : BaseRepository, IOrderRepository
{
    public OrderRepository(OrderContext context) : base(context)
    {
    }

    public async Task<Order> Add(Order order)
    {
        return await base.Add(order);
    }

    public async Task<Order> Update(Order order)
    {
        return await base.Update(order);
    }

    public async Task<Order> Delete(int orderId)
    {
        var order = await base.GetById<Order>(orderId) 
            ?? throw new Exception("Order not found");
        return await base.Delete(order);
    }

    public async Task<Order?> GetById(int orderId)
    {
        return await base.GetById<Order>(orderId);
    }

    public async Task<List<Order>> GetAll()
    {
        return await base.GetAll<Order>();
    }
}
