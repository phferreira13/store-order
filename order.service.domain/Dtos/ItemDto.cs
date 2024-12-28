using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.service.domain.Dtos
{
    public record ItemDto(
        Guid Id,
        string Name,
        decimal Price,
        string Description,
        DateTime CreatedAt,
        DateTime? UpdatedAt)
    { }
}
