using MediatR;
using Microsoft.Extensions.Logging;
using Redzone.Application.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Redzone.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<CreateOrderCommandHandler> _logger;
        public CreateOrderCommandHandler(IOrderRepository orderRepository, ILogger<CreateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.MapToModel();
            var newOrder = await _orderRepository.AddAsync(order);
            _logger.LogInformation($"Order {newOrder.Id} is successfully created.");
            return newOrder.Id;
        }
    }
}
