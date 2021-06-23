using MediatR;
using Microsoft.Extensions.Logging;
using Redzone.Application.Exceptions;
using Redzone.Application.Persistence;
using Redzone.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Redzone.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;
        public UpdateOrderCommandHandler(IOrderRepository orderRepository, ILogger<UpdateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {

            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Guid);
            if (orderToUpdate == null)
            {
                throw new NotFoundException(nameof(Order), request.Guid);
            }
            var model = request.MapToModel(orderToUpdate);
            await _orderRepository.UpdateAsync(model);
            _logger.LogInformation($"Order {orderToUpdate.Id} is successfully updated.");
            return Unit.Value;

        }
    }
}
