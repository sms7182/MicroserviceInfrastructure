using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FatalError.Communication
{

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostin, config) =>
            {
              
              var env=  Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                Console.WriteLine(env);
                if (hostin.HostingEnvironment.IsDevelopment())
                {
                    Console.WriteLine("DEVELOPMENT");
                    config.AddJsonFile($"appsettings.Development.json", optional: false, reloadOnChange: true).AddEnvironmentVariables().Build();
                }
                else if(hostin.HostingEnvironment.IsProduction())
                {
                    config.AddJsonFile($"appsettings.Production.json", optional: false, reloadOnChange: true).Build();
                }
                else
                {
                    Console.WriteLine("not found");
                }
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    
                    webBuilder.UseStartup<Startup>();
                });
    }
}
