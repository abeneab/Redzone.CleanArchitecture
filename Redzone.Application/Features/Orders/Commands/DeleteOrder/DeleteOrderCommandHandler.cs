using MediatR;
using Microsoft.Extensions.Logging;
using Redzone.Application.Exceptions;
using Redzone.Application.Persistence;
using Redzone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redzone.Application.Features.Orders.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository, ILogger<DeleteOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.ID);
            if (order == null)
            {
                throw new NotFoundException(nameof(Order), request.ID);
            }
            await _orderRepository.DeleteAsync(order);
            _logger.LogInformation($"Order {order.Id} is successfully deleted.");
            return Unit.Value;
        }
    }
}
