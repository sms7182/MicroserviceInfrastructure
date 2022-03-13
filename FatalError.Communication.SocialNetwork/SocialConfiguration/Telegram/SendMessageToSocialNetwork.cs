using DotNetCore.CAP;
using FatalError.Communication.Contracts;
using FatalError.Communication.Contracts.SocialNetwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FatalError.Communication.SocialNetwork.SocialConfiguration.Telegram
{
    public class SendMessageToSocialNetwork : ISendMessageToSocialNetwork
    {
        TelegramBotClient telegramBotClient;
        ICapPublisher capPublisher;
        public SendMessageToSocialNetwork(TelegramBotClient _telegramBotClient,ICapPublisher _capPublisher)
        {
            telegramBotClient = _telegramBotClient;
            capPublisher = _capPublisher;
        }
        public async Task SendToTelegram(long chatId,string receiver, string message)
        {
           await telegramBotClient.SendTextMessageAsync(new ChatId(chatId), message);

            await capPublisher.PublishAsync(nameof(SendMessageEvent), new SendMessageEvent()
            {
                SocialNetworkType = SocialNetworkType.Telegram,
                CreationDate = DateTime.UtcNow,
                Message = message,
                Sender = "owner",
                Receiver = receiver
            });

        }
    }
}
