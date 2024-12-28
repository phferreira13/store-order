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
        Order? GetById(Guid id);
        void Add(Order order);
        void Update(Order order);
        void Delete(Guid id);
    }
}
