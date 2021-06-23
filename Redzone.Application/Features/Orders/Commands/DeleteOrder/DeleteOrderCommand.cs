using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redzone.Application.Features.Orders.Commands
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
