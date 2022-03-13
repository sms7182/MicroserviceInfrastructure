using FatalError.Communication.Contracts;
using FatalError.Communication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FatalError.Communication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<NotificationsController> _logger;
        IHubContext<CommunicationService, ICommunicationService> hub;
       
        public NotificationsController(ILogger<NotificationsController> logger,
            IHubContext<CommunicationService, ICommunicationService> context)
           
        {
            _logger = logger;
            hub = context;
        }


        [HttpGet("notificationcount")]
        public async Task<IEnumerable<WeatherForecast>> NotificationCount()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("notificationresult")]
        public async Task<IEnumerable<WeatherForecast>> NotificationResult()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("notifyMe")]
        public async Task<IActionResult> NotifyMe()
        {
            
           //await hubContext.Clients.All.SendAsync("BroadcastMessage",new MessageInfo()
           //{
           //    Message="Bonjour ma amie",
           //    UserName="FatalError"
           //});
            return Ok();
        }

        //[HttpPost("sendMessage")]
        //public async Task<IActionResult> SendMessage([FromBody]MessageInfo message)
        //{
        //    await communicationService.SendMessage(message.UserName, message.Message);
        //    return Ok();
        //}
    }
   

}
