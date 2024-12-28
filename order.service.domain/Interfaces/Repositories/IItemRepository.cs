using order.service.domain.Dtos;
using order.service.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.service.domain.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task<ItemDto?> GetByIdAsync(Guid itemId);
        void Add(ItemDto item);
        Task<IEnumerable<ItemDto>> GetAll();
    }
}
