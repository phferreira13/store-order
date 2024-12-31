namespace order.service.domain.Dtos;

public record ItemDto(
    int Id,
    string Name,
    decimal Price,
    string Description,
    DateTime CreatedAt,
    DateTime? UpdatedAt)
{ }
