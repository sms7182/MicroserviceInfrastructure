using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Core.Data.Configuration
{
    public static class PostgresConfiguration
    {
        public static IServiceCollection AddPostgresWrite<T>(this IServiceCollection services,IConfiguration configuration) where T:DbContext
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<T>(options =>
            {
                options.UseNpgsql(configuration["messageDBConnection"], d => d.MigrationsAssembly(typeof(T).Assembly.GetName().Name));
            });

            return services;
    
        }

        public static IServiceCollection AddPostgresRead<T>(this IServiceCollection services,  IConfiguration configuration) where T : DbContext
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<T>(options =>
            {
                options.UseNpgsql(configuration["readmessageDBConnection"], d => d.MigrationsAssembly(typeof(T).Assembly.GetName().Name));
            });

            return services;

        }
    }
}
