using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redzone.Application.Persistence;
using Redzone.Infrastructure.Contexts;
using Redzone.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redzone.Infrastructure
{
    public static class InfrastructureServiceRegistation
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("OrderingConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
