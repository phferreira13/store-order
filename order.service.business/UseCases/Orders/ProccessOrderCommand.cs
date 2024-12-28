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
    public class ProccessOrderCommand(Guid id) : IRequest<Order>
    {
        public Guid Id { get; private set; } = id;

        internal class Handler(IOrderRepository orderRepository) : IRequestHandler<ProccessOrderCommand, Order>
        {
            private readonly IOrderRepository _orderRepository = orderRepository;

            public async Task<Order> Handle(ProccessOrderCommand request, CancellationToken cancellationToken)
            {
                var order = _orderRepository.GetById(request.Id)
                    ?? throw new Exception($"Order with id {request.Id} not found.");

                order.Proccess();

                _orderRepository.Update(order);
                return await Task.FromResult(order);
            }
        }
    }
}
