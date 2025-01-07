using order.service.domain.Dtos;
using order.service.domain.Interfaces.HttpClients;
using order.service.domain.Interfaces.Services;

namespace order.service.business.Services;
public class ItemService : IItemService
{
    private readonly IWarehouseHttpClient _warehouseHttpClient;

    public ItemService(IWarehouseHttpClient warehouseHttpClient)
    {
        _warehouseHttpClient = warehouseHttpClient;
    }

    public async Task<ItemDto?> GetByIdAsync(int itemId)
    {
        var warehouses = await _warehouseHttpClient.GetWarehousesAsync();

        var items = warehouses.SelectMany(w => w.Items.Select(i => i.Item));
        return items.FirstOrDefault(i => i.Id == itemId);
    }

    public async Task<IEnumerable<ItemDto>> GetAllItemsAsync()
    {
        var warehouses = await _warehouseHttpClient.GetWarehousesAsync();

        var items = warehouses.SelectMany(w => w.Items.Select(i => i.Item));
        return items;
    }
}
