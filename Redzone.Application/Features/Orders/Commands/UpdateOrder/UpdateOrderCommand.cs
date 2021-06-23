using MediatR;
using Redzone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redzone.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : OrderEntity,IRequest
    {
    }
}
