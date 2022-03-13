using DotNetCore.CAP;
using FatalError.Core.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Core.CAP.Configuration
{
    public static class CAPConfiuration
    {
        static IServiceCollection AddCAP(this IServiceCollection services, string capDB, string dbConnection, string rabbitHost, string rabbitUser, string rabbitPass)
        {
            services.AddCap(x =>
            {
                x.UseMongoDB(mo => { mo.DatabaseName = capDB; mo.DatabaseConnection = dbConnection; });
                x.UseRabbitMQ(rabbit => { rabbit.HostName = rabbitHost; rabbit.Port = 5672; rabbit.UserName = rabbitUser; rabbit.Password = rabbitPass; });


            });

            return services;
        }

        public static IServiceCollection AddEventHandler<T>(this IServiceCollection services,IConfiguration configuration) where T : ICapSubscribe
        {
            var settings =configuration.GetSection(typeof(CAPSettings).Name).Get<CAPSettings>();
            

            services.AddCAP(settings.CAPDBName,settings.CAPDBHost, settings.RabbitMQHost,settings.RabbitUser, settings.RabbitPass);
            var types = typeof(T).Assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.BaseType != null && type.BaseType.IsGenericType && typeof(Event).IsAssignableFrom(type.BaseType.GenericTypeArguments[0]))
                {
                    services.AddTransient(type);
                }
            }

            return services;
        }

    }

   


}
