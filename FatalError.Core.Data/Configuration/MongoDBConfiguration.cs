using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Core.Data.Configuration
{
   public static class MongoDBConfiguration
    {
        public static IServiceCollection AddMongoDB(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
           serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            return services;
        } 
    }
}
