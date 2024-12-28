using order.service.domain.Interfaces.Repositories;
using order.service.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.service.domain.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> _orders = new();

        public Order? GetById(Guid id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public void Add(Order order)
        {
            _orders.Add(order);
        }

        public void Update(Order order)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.Id == order.Id);
            if (existingOrder != null)
            {
                _orders.Remove(existingOrder);
                _orders.Add(order);
            }
        }

        public void Delete(Guid id)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.Id == id);
            if (existingOrder != null)
            {
                _orders.Remove(existingOrder);
            }
        }
    }
}
