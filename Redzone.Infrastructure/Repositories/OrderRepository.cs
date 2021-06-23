using Redzone.Application.Persistence;
using Redzone.Domain.Models;
using Redzone.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redzone.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {

        public OrderRepository(OrderContext context): base(context)
        {

        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = (await GetQueryAsync(x => x.UserName == userName)).ToList();
            return orderList;
        }
    }
}
