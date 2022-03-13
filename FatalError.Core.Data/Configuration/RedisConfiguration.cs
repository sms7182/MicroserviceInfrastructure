using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Core.Data.Configuration
{
    public static class RedisConfiguration
    {
        public static IServiceCollection AddRedis(this IServiceCollection services,IConfiguration configuration)
        {
            var redis = ConnectionMultiplexer.Connect(
         new ConfigurationOptions
         {
             EndPoints = { configuration["RedisServer"] },
             ResolveDns = true,

         }
         );
            services.AddSingleton<IConnectionMultiplexer>(redis);
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["RedisServer"];
                options.InstanceName = "FatalError";
            });
            return services;
        }
    }
}
