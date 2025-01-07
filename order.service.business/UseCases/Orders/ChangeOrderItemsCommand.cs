using MediatR;
using order.service.domain.Interfaces.Repositories;
using order.service.domain.Interfaces.Services;
using order.service.domain.Models;

namespace order.service.business.UseCases.Orders
{
    public class ChangeOrderItemsCommand : IRequest<Order>
    {
        private int OrderId { get; set; }
        private int ItemId { get; set; }
        public int Quantity { get; set; }

        public void SetOrderId(int orderId) => OrderId = orderId;
        public void SetItemId(int itemId) => ItemId = itemId;

        internal class Handler : IRequestHandler<ChangeOrderItemsCommand, Order>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IItemService _itemService;

            public Handler(IOrderRepository orderRepository, IItemService itemService)
            {
                _orderRepository = orderRepository;
                _itemService = itemService;
            }

            public async Task<Order> Handle(ChangeOrderItemsCommand request, CancellationToken cancellationToken)
            {
                var order = await _orderRepository.GetByIdAsync(request.OrderId)
                    ?? throw new Exception($"Order with id {request.OrderId} not found.");

                var item = await _itemService.GetByIdAsync(request.ItemId)
                    ?? throw new Exception($"Item with id {request.ItemId} not found.");

                if (request.Quantity < 0)
                {
                    order.RemoveItem(item, Math.Abs(request.Quantity));
                }
                else
                {
                    order.AddItem(item, request.Quantity);
                }

                await _orderRepository.UpdateAsync(order);
                return order;
            }
        }


    }
}
