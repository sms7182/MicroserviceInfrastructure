using FatalError.Communication.Contracts;
using FatalError.Communication.Contracts.CacheProvider;
using FatalError.Communication.Contracts.SocialNetwork;
using FatalError.Communication.Controllers;
using FatalError.Communication.SocialNetwork.SocialConfiguration.Telegram;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FatalError.Communication.Services
{
    public class CommunicationService: Hub<ICommunicationService>
    {
      
       
        ISendMessageToSocialNetwork sendMessageToSocialNetwork;
        ICacheProvider cacheProvider;
        public CommunicationService(ISendMessageToSocialNetwork _sendMessageToSocialNetwork, ICacheProvider _cacheProvider)
        {
            sendMessageToSocialNetwork = _sendMessageToSocialNetwork;

            cacheProvider = _cacheProvider;
        }



        public async Task SendMessage(string message, string userName)
        {
           var userInfoJson =await cacheProvider.Get(userName);
            if (!string.IsNullOrWhiteSpace(userInfoJson))
            {
                var userInfo = JsonConvert.DeserializeObject<UserInfo>(userInfoJson);
                if (userInfo != null)
                {
                   
                    await sendMessageToSocialNetwork.SendToTelegram(userInfo.ChatId,userName, message);
                }
            }
        }

    }
}
