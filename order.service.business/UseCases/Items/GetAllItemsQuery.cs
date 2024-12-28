using MediatR;
using order.service.domain.Dtos;
using order.service.domain.Interfaces.Repositories;
using order.service.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.service.business.UseCases.Items
{
    public class GetAllItemsQuery : IRequest<IEnumerable<ItemDto>>
    {
        internal class Handler(IItemRepository itemRepository) : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemDto>>
        {
            private readonly IItemRepository _itemRepository = itemRepository;

            public async Task<IEnumerable<ItemDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
            {
                return await _itemRepository.GetAll();
            }
        }
    }
}
