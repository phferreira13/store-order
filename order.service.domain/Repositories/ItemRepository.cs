using order.service.domain.Dtos;
using order.service.domain.Interfaces.HttpClients;
using order.service.domain.Interfaces.Repositories;

namespace order.service.domain.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private List<ItemDto> _items = new();
        private readonly IWarehouseHttpClient _warehouseHttpClient;

        public ItemRepository(IWarehouseHttpClient warehouseHttpClient)
        {
            _warehouseHttpClient = warehouseHttpClient;
        }

        public void Add(ItemDto item)
        {
            _items.Add(item);
        }

        public async Task<ItemDto?> GetByIdAsync(Guid itemId)
        {
            var warehouses = await _warehouseHttpClient.GetWarehousesAsync();

            var items = warehouses.SelectMany(w => w.Items.Select(i => i.Item));
            return items.FirstOrDefault(i => i.Id == itemId);
        }

        public async Task<IEnumerable<ItemDto>> GetAll()
        {
            var warehouses = await _warehouseHttpClient.GetWarehousesAsync();

            var items = warehouses.SelectMany(w => w.Items.Select(i => i.Item));
            return items;
        }
    }
}
