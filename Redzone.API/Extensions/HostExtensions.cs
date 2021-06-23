using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redzone.API.Extensions
{
    public  static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host,Action<TContext,IServiceProvider> action) where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope()) 
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();
                try
                {
                    logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);
                    InvokeSeeder(action, context, services);
                    logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
                }
                catch (Exception e)
                {
                    logger.LogError($"Migrating Error Occured {e.Message }");
                }

            }
            return host;
        }

        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services) where TContext : DbContext
        {
            context.Database.Migrate();
            seeder(context, services);
        }
    }
}
