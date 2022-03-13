using DotNetCore.CAP;
using FatalError.Communication.Contracts;
using FatalError.Communication.Contracts.CacheProvider;
using FatalError.Communication.Contracts.SocialNetwork;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FatalError.Communication.SocialNetwork.SocialConfiguration.Telegram
{
    
    public static   class UpdateHandler
    {
        private static ISignalService signalService;
        private static ICacheProvider cacheProvider;
        private static ICapPublisher capPublisher;

        public static void UpdateHandlerConfiguration(ISignalService _signalService,ICacheProvider _cacheProvider,ICapPublisher _capPublisher)
        {
            signalService = _signalService;
            cacheProvider = _cacheProvider;
            capPublisher = _capPublisher;
            
        }
      
        public  static Task HandleError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
          
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        public static async Task HandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                
                UpdateType.Message => BotOnMessageReceived(botClient, update.Message,signalService),
                UpdateType.EditedMessage => BotOnMessageReceived(botClient, update.EditedMessage,signalService),
         //       UpdateType.CallbackQuery => BotOnCallbackQueryReceived(botClient, update.CallbackQuery),
           //     UpdateType.InlineQuery => BotOnInlineQueryReceived(botClient, update.InlineQuery),
             //   UpdateType.ChosenInlineResult => BotOnChosenInlineResultReceived(botClient, update.ChosenInlineResult),
               // _ => UnknownUpdateHandlerAsync(botClient, update)
            };

            try
            {
                await handler;
            }
            catch (Exception exception)
            {
                await HandleError(botClient, exception, cancellationToken);
            }
        }
        private static async Task BotOnMessageReceived(ITelegramBotClient botClient, Message message,ISignalService _signalService)
        {
           
            if (message.Type == MessageType.Text)
            {

               var userinfoJson=await cacheProvider.Get(message.From.Username);
                UserInfo userInfo;
             //   if (string.IsNullOrEmpty(userinfoJson))
                {
                    userInfo= new UserInfo()
                    {
                        ChatId = message.Chat.Id,
                        
                        SocialType = SocialNetworkType.Telegram,
                        UserName = message.From.Username
                    };
                    userinfoJson= JsonConvert.SerializeObject(userInfo);
                    cacheProvider.Set(message.From.Username, userinfoJson);
                    var messageReceived = new MessageReceiveEvent()
                    {
                        ChatId = message.Chat.Id,
                        Message=message.Text,
                        Receiver="owner",
                        Sender=message.From.Username,
                        SocialNetworkType=SocialNetworkType.Telegram,
                        CreationDate=DateTime.UtcNow
                    };
                   await capPublisher.PublishAsync<MessageReceiveEvent>(nameof(MessageReceiveEvent), messageReceived);
                }
                userInfo= JsonConvert.DeserializeObject<UserInfo>(userinfoJson);
              await  _signalService.SendMessage(message.From.Username,message.Text,userInfo.UserId);
                return;
            }

        }
    }
}
