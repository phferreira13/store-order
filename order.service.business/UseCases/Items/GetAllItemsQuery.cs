using MediatR;
using order.service.domain.Dtos;
using order.service.domain.Interfaces.Services;

namespace order.service.business.UseCases.Items
{
    public class GetAllItemsQuery : IRequest<IEnumerable<ItemDto>>
    {
        internal class Handler(IItemService itemService) : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemDto>>
        {
            public async Task<IEnumerable<ItemDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
            {
                return await itemService.GetAllItemsAsync();
            }
        }
    }
}
