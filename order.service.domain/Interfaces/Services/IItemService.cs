using order.service.domain.Dtos;

namespace order.service.domain.Interfaces.Services;
public interface IItemService
{
    Task<ItemDto?> GetByIdAsync(int itemId);
    Task<IEnumerable<ItemDto>> GetAllItemsAsync();
}
