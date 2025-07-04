﻿using MediatR;
using order.service.domain.Interfaces.Repositories;
using order.service.domain.Interfaces.Services;
using order.service.domain.Models;

namespace order.service.business.UseCases.Orders
{
    public class AddOrderCommand : IRequest<Order>
    {
        public string Customer { get; set; }
        public List<AddOrderItem> Items { get; set; } = [];

        public class AddOrderItem
        {
            public int ItemId { get; set; }
            public int Quantity { get; set; }
        }

        public static implicit operator Order(AddOrderCommand command)
        {
            var order = new Order(command.Customer);
            return order;
        }

        internal class Handler : IRequestHandler<AddOrderCommand, Order>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IItemService _itemService;

            public Handler(IOrderRepository orderRepository, IItemService itemService)
            {
                _orderRepository = orderRepository;
                _itemService = itemService;
            }

            public async Task<Order> Handle(AddOrderCommand request, CancellationToken cancellationToken)
            {
                Order order = request;
                foreach (var item in request.Items)
                {
                    var itemEntity = await _itemService.GetByIdAsync(item.ItemId);
                    if (itemEntity == null)
                    {
                        throw new Exception($"Item with id {item.ItemId} not found.");
                    }
                    order.AddItem(itemEntity, item.Quantity);
                }
                await _orderRepository.AddAsync(order);
                return order;
            }
        }
    }
}
