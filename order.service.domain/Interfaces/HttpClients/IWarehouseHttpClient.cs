using order.service.domain.Dtos;

namespace order.service.domain.Interfaces.HttpClients
{
    public interface IWarehouseHttpClient
    {
        Task<IEnumerable<WarehouseDto>> GetWarehousesAsync();
    }
}
