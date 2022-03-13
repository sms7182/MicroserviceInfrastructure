using FatalError.Communication.Domain;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FatalError.Communication
{
    public class TrackingMiddleware:IMiddleware
    {
      
        private IServiceProvider serviceProvider;


        public TrackingMiddleware(IServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var messageMongoRepository = (IMessageMongoRepository)serviceProvider.GetService(typeof(IMessageMongoRepository));
            if (context.Request.Headers.TryGetValue("trackingid", out var temp))
            {
                if ( Guid.TryParse(temp.ToString(), out Guid id))
                {
                    messageMongoRepository.Id = id;
                }
            }

            await next(context);
        }
    }
}
