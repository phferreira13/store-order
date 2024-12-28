using order.service.domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.service.domain.Interfaces.HttpClients
{
    public interface IWarehouseHttpClient
    {
        Task<IEnumerable<WarehouseDto>> GetWarehousesAsync();
    }
}
