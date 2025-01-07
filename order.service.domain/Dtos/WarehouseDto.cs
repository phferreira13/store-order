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
