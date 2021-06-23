using MediatR;
using Redzone.Application.Persistence;
using Redzone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redzone.Application.Features.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<OrderEntity>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderListQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }
        public async Task<List<OrderEntity>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrdersByUserName(request.UserName);
            return orderList?.Select(o => new OrderEntity(o)).ToList();

        }
    }
}
