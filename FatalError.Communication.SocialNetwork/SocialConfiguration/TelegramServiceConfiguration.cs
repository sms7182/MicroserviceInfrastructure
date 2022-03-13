using FatalError.Communication.SocialNetwork.SocialConfiguration.Telegram;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;

namespace FatalError.Communication.SocialNetwork.SocialConfiguration
{
    public static class TelegramServiceConfiguration
    {
        private static TelegramBotClient? bot;
        private static readonly string access = "";
        public  static IServiceCollection AddTelegramService(this IServiceCollection services)
        {
            bot = new TelegramBotClient(access);
             bot.GetMeAsync().Wait();
            using var cts = new CancellationTokenSource();
            
            bot.StartReceiving(new DefaultUpdateHandler(UpdateHandler.HandleUpdate, UpdateHandler.HandleError),cts.Token);
         
            return services;
        }
    }
}
