using order.service.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static order.service.domain.Dtos.WarehouseDto;

namespace order.service.domain.Dtos
{
    public record WarehouseDto(
        Guid Id,
        string Name,
        string Location,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        List<WarehouseItemDto> Items)
    {
        public record WarehouseItemDto(
            Guid Id,
            ItemDto Item,
            int Quantity,
            DateTime CreatedAt,
            DateTime? UpdatedAt)
        { }
    }
}
