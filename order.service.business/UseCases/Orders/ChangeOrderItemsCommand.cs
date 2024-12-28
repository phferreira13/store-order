using MediatR;
using order.service.domain.Interfaces.Repositories;
using order.service.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.service.business.UseCases.Orders
{
    public class ChangeOrderItemsCommand : IRequest<Order>
    {
        private Guid OrderId { get; set; }
        private Guid ItemId { get; set; }
        public int Quantity { get; set; }

        public void SetOrderId(Guid orderId) => OrderId = orderId;
        public void SetItemId(Guid itemId) => ItemId = itemId;

        internal class Handler : IRequestHandler<ChangeOrderItemsCommand, Order>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IItemRepository _itemRepository;

            public Handler(IOrderRepository orderRepository, IItemRepository itemRepository)
            {
                _orderRepository = orderRepository;
                _itemRepository = itemRepository;
            }

            public async Task<Order> Handle(ChangeOrderItemsCommand request, CancellationToken cancellationToken)
            {
                var order = _orderRepository.GetById(request.OrderId)
                    ?? throw new Exception($"Order with id {request.OrderId} not found.");

                var item = await _itemRepository.GetByIdAsync(request.ItemId) 
                    ?? throw new Exception($"Item with id {request.ItemId} not found.");

                if (request.Quantity < 0)
                {
                    order.ItemList.RemoveItem(item, Math.Abs(request.Quantity));
                }
                else
                {
                    order.ItemList.AddItem(item, request.Quantity);
                }

                _orderRepository.Update(order);
                return order;
            }
        }


    }
}
