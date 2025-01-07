using MediatR;
using order.service.domain.Interfaces.Repositories;
using order.service.domain.Models;

namespace order.service.business.UseCases.Orders
{
    public class ProccessOrderCommand(int id) : IRequest<Order>
    {
        public int Id { get; private set; } = id;

        internal class Handler(IOrderRepository orderRepository) : IRequestHandler<ProccessOrderCommand, Order>
        {
            private readonly IOrderRepository _orderRepository = orderRepository;

            public async Task<Order> Handle(ProccessOrderCommand request, CancellationToken cancellationToken)
            {
                var order = await _orderRepository.GetByIdAsync(request.Id)
                    ?? throw new Exception($"Order with id {request.Id} not found.");

                order.Proccess();

                await _orderRepository.UpdateAsync(order);
                return await Task.FromResult(order);
            }
        }
    }
}
