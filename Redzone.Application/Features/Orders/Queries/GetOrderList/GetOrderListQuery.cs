using MediatR;
using Redzone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redzone.Application.Features.Orders.Queries.GetOrderList
{
    public class GetOrderListQuery : IRequest<List<OrderEntity>>
    {
        public string UserName { get; set; }

        public GetOrderListQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
