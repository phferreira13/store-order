using order.service.domain.Models;

namespace order.service.domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order order);
        Task<Order> UpdateAsync(Order order);
        Task<Order> DeleteAsync(int id);
        Task<Order?> GetByIdAsync(int id);
        Task<List<Order>> GetAllAsync();
    }
}
