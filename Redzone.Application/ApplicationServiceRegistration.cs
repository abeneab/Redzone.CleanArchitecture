using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Redzone.Application.Behaviours;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FluentValidation;
using Redzone.Domain.Interfaces;
using Redzone.Application.Services;

namespace Redzone.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
