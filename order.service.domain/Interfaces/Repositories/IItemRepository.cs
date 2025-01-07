using order.service.domain.Dtos;

namespace order.service.domain.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task<ItemDto?> GetByIdAsync(Guid itemId);
        void Add(ItemDto item);
        Task<IEnumerable<ItemDto>> GetAll();
    }
}
