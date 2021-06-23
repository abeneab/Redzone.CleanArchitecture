using Redzone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redzone.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderEntity>> GetOrderByUser(string userName);
        Task<Guid> AddAsync(OrderEntity orderEntity);
        Task UpdateAsync(OrderEntity orderEntity);
        Task<OrderEntity> GetByIdAsync(Guid guid);
        Task<IEnumerable<OrderEntity>> GetAllOrders();
        Task DeleteOrder(Guid guid);
    }
}
