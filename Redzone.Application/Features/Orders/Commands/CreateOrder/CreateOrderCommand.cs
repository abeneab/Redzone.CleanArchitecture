using MediatR;
using Redzone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redzone.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : OrderEntity, IRequest<Guid>
    {
    }
}
