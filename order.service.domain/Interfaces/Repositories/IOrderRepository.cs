using order.service.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.service.domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> Add(Order order);
        Task<Order> Update(Order order);
        Task<Order> Delete(int id);
        Task<Order?> GetById(int id);
        Task<List<Order>> GetAll();
    }
}
