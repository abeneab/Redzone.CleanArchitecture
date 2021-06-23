using Microsoft.Extensions.Logging;
using Redzone.Application.Exceptions;
using Redzone.Application.Persistence;
using Redzone.Domain.Entities;
using Redzone.Domain.Interfaces;
using Redzone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redzone.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;
        public OrderService(IOrderRepository orderRepository,ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<Guid> AddAsync(OrderEntity orderEntity)
        {
            var model = orderEntity.MapToModel();
            var data = await _orderRepository.AddAsync(model);
            return data.Id;
        }

        public async Task DeleteOrder(Guid guid)
        {
            try
            {
                var order = await _orderRepository.GetByIdAsync(guid);
                if(order == null)
                    throw new NotFoundException(nameof(Order), guid);
                await _orderRepository.DeleteAsync(order);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error Occured : {e.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<OrderEntity>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders?.Select(o => new OrderEntity(o)).ToList(); 
        }

        public async Task<OrderEntity> GetByIdAsync(Guid guid)
        {
            var order = await _orderRepository.GetByIdAsync(guid);
            return new OrderEntity(order);
        }

        public async Task<IEnumerable<OrderEntity>> GetOrderByUser(string userName)
        {
            try
            {
                var order = (await _orderRepository.GetQueryAsync(x => x.UserName == userName)).ToList();
                return order?.Select(x=> new OrderEntity(x));
            }
            catch (Exception e)
            {

                _logger.LogError($"Error Occured : {e.Message}");
                return Enumerable.Empty<OrderEntity>();
            }
        }
        
        public async Task UpdateAsync(OrderEntity orderEntity)
        {
            try
            {
                await _orderRepository.UpdateAsync(orderEntity.MapToModel());
            }
            catch (Exception e)
            {
                _logger.LogError($"Error Occured : {e.Message}");
            }
        }
    }
}
