using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redzone.API.Models;
using Redzone.Domain.Entities;
using Redzone.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Redzone.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("{userName}", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<OrderEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderEntity>>> GetOrdersByUserName(string userName)
        {
            var orders = await _orderService.GetOrderByUser(userName);
            return Ok(orders);
        }
        [HttpPost(Name = "CheckoutOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CheckoutOrder([FromBody] OrderPostModel command)
        {
            var newOrder = await _orderService.AddAsync(command.MapToEntity<OrderEntity>());
            return Ok(newOrder);
        }
        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] OrderPostModel command)
        {
             await _orderService.UpdateAsync(command.MapToEntity<OrderEntity>());
            return NoContent();
        }
        [HttpDelete("{guid}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(Guid guid)
        {
            await _orderService.DeleteOrder(guid);
            return NoContent();
        }
    }

}
