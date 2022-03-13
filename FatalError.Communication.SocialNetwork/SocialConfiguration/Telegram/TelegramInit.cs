using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Telegram.Bot;

namespace FatalError.Communication.SocialNetwork.SocialConfiguration.Telegram
{
    public class TelegramInit
    {
        private static readonly string access = "1970508617:AAFSQuAexr2y-HwVhlutAgNhay-KjJUrUJY";
        private static  readonly TelegramBotClient bot = new TelegramBotClient(access);
         HttpClient client;
        public TelegramBotClient TelegramBotClient { get; set; }
        public TelegramInit()
        {
            var baseUrl = $"https://api.telegram.org/bot{access}/";
            client = new HttpClient();

         
            var chatid = "900855965";
            var instance = new ChatBotRequest()
            {
                AccessToken = access,
                ChatId = chatid,
                Text = "@bug:hi"
            };

            var tel = new Setting()
            {
                BaseUrl = baseUrl,
                EndPoints = new EndPoints()
                {
                    SendMessage = "sendMessage"
                }
            };

            client.BaseAddress = new Uri(baseUrl);
            TelegramBotClient = new TelegramBotClient(access);


        }

    }
   
}
