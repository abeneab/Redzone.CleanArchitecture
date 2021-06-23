using Microsoft.Extensions.Logging;
using Redzone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redzone.Infrastructure.Contexts
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext,ILogger<OrderContextSeed> logger) 
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);

            }
        }
        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "user", FirstName = "Unconditional", LastName = "Love", EmailAddress = "someemail@gmail.com", AddressLine = "Bahcelievler", Country = "Ethiopia", TotalPrice = 350 }
            };
        }
    }
}
