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
    public class GetOrderQuery(Guid orderId) : IRequest<Order>
    {
        public Guid OrderId { get; set; } = orderId;

        internal class Handler : IRequestHandler<GetOrderQuery, Order?>
        {
            private readonly IOrderRepository _orderRepository;

            public Handler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<Order?> Handle(GetOrderQuery request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(_orderRepository.GetById(request.OrderId));
            }
        }
    }
}
