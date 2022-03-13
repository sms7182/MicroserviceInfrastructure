using FatalError.Communication.ApplicationService.EventHandlers;
using FatalError.Communication.ApplicationService.Queries;
using FatalError.Core.CAP.Configuration;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FatalError.Communication.ApplicationService.Configurations
{
   
    public static class ApplicationServiceConfiguration
    {
        private static IServiceCollection AddMediatorHandlers(this IServiceCollection services, Assembly assembly)
        {
            var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in classTypes)
            {
                var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                foreach (var handlerType in interfaces.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                {
                    services.AddTransient(handlerType.AsType(), type.AsType());
                }

                //foreach (var handlerType in interfaces.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IAsyncRequestHandler<,>)))
                //{
                //    services.AddTransient(handlerType.AsType(), type.AsType());
                //}
            }

            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddEventHandler<SendMessageEventHandler>(configuration);
            services.AddMediatR(typeof(GetMessageQueryHandler));

            services.AddMediatorHandlers(typeof(GetMessageQueryHandler).Assembly);

            return services;
        }
    }
}
