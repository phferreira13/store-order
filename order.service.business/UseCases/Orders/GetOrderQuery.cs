using MediatR;
using order.service.domain.Interfaces.Repositories;
using order.service.domain.Models;

namespace order.service.business.UseCases.Orders
{
    public class GetOrderQuery(int orderId) : IRequest<Order>
    {
        public int OrderId { get; set; } = orderId;

        internal class Handler : IRequestHandler<GetOrderQuery, Order?>
        {
            private readonly IOrderRepository _orderRepository;

            public Handler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<Order?> Handle(GetOrderQuery request, CancellationToken cancellationToken)
            {
                return await _orderRepository.GetByIdAsync(request.OrderId);
            }
        }
    }
}
