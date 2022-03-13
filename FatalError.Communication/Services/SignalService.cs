using FatalError.Communication.Contracts;
using FatalError.Communication.Contracts.SocialNetwork;
using FatalError.Communication.Controllers;
using FatalError.Communication.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FatalError.Communication.SocialNetwork.SocialConfiguration.Telegram
{
  
    public class SignalService : ISignalService
    {
        IHubContext<CommunicationService, ICommunicationService> hub;
        public SignalService(IHubContext<CommunicationService,ICommunicationService> _hub)
        {

            hub = _hub;
          

        }

        public async Task SendMessage(string user,string message,Guid id)
        {
            await hub.Clients.All.BroadcastMessage(new MessageInfo() { Message = message, UserName = user,UserId=id,Sender=user,Receiver="Owner" });

        }

        
    }
}
