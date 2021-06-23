using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redzone.Application.Features.Orders.Commands;
using Redzone.Application.Features.Orders.Commands.CreateOrder;
using Redzone.Application.Features.Orders.Commands.UpdateOrder;
using Redzone.Application.Features.Orders.Queries.GetOrderList;
using Redzone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Redzone.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderCQRSController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderCQRSController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet("{userName}", Name = "GetOrderQuery")]
        [ProducesResponseType(typeof(IEnumerable<OrderEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderEntity>>> GetOrdersByUserName(string userName)
        {
            var query = new GetOrderListQuery(userName);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }
        [HttpPost(Name = "CheckoutOrderQuery")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CheckoutOrder([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut(Name = "UpdateOrderQuery")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{guid}", Name = "DeleteOrderQuery")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(Guid guid)
        {
            var command = new DeleteOrderCommand() { ID = guid };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
