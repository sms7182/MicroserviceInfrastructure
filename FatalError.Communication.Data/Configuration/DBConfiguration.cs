using FatalError.Communication.Contracts.CacheProvider;
using FatalError.Communication.Data.Repositories.NoSqlRepository;
using FatalError.Communication.Domain;
using FatalError.Communication.SocialNetwork.Core;
using FatalError.Core.Data.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Data.Configuration
{
    public static class DBConfiguration
    {
        public static IServiceCollection AddDataBaseConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddMongoDB(configuration);

            services.AddRedis(configuration);
            services.AddSingleton<ICacheProvider, CacheProvider>();
            services.AddPostgresWrite<WriteApplicationDBContext>(configuration);
            services.AddPostgresRead<ReadApplicationDBContext>(configuration);

            services.AddScoped<IMessageMongoRepository, MessageMongoRepository>();
            services.AddScoped<ICommunicationUnitOfWork, CommunicationUnitOfWork>();
            services.AddScoped<ICommunicationReadUnitOfWork, CommunicationReadUnitOfWork>();


            return services;
        }
    }
}
