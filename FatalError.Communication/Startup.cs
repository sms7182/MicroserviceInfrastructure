using DotNetCore.CAP;
using FatalError.Communication.ApplicationService.Configurations;
using FatalError.Communication.ApplicationService.EventHandlers;
using FatalError.Communication.ApplicationService.Queries;
using FatalError.Communication.Contracts;
using FatalError.Communication.Contracts.CacheProvider;
using FatalError.Communication.Contracts.SocialNetwork;
using FatalError.Communication.Data.Configuration;
using FatalError.Communication.Data.Repositories;
using FatalError.Communication.Data.Repositories.NoSqlRepository;
using FatalError.Communication.Domain;
using FatalError.Communication.Services;
using FatalError.Communication.SocialNetwork.Core;
using FatalError.Communication.SocialNetwork.SocialConfiguration;
using FatalError.Communication.SocialNetwork.SocialConfiguration.Telegram;
using FatalError.Core.CAP.Configuration;
using FatalError.Core.Data.Configuration;
using FatalError.Core.Data.MongoDataInfrastructure;
using FatalError.Core.DataAccess.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Telegram.Bot;

namespace FatalError.Communication
{
 
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public string mypolicy = "mypolicy";
        private string access = "1970508617:AAFSQuAexr2y-HwVhlutAgNhay-KjJUrUJY";
        // This method gets called by the runtime. Use this method to add services to the container.
     
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllers();


            services.AddDataBaseConfiguration(Configuration);
           services.AddTelegramService();
            services.AddSignalR();
            
            services.AddSingleton<ISignalService, SignalService>();

            services.AddTransient<TrackingMiddleware>();
            services.AddSingleton(new TelegramBotClient(access));
            services.AddSingleton<ISendMessageToSocialNetwork, SendMessageToSocialNetwork>();
            services.AddApplicationServices(Configuration);
            services.AddCors(options =>
            {
                options.AddPolicy(mypolicy, builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed((host) => true));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FatalError.Communication", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FatalError.Communication v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
          
            app.UseCors(mypolicy);
            
            app.UseAuthorization();
            app.UseMiddleware<TrackingMiddleware>();
            UpdateHandler.UpdateHandlerConfiguration(app.ApplicationServices.GetService<ISignalService>(),app.ApplicationServices.GetService<ICacheProvider>(),app.ApplicationServices.GetService<ICapPublisher>());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<CommunicationService>("/notify");
                endpoints.MapControllers();
            });
           
        }
    }
}
