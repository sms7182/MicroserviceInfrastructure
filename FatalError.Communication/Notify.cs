using FatalError.Communication.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FatalError.Communication
{
    //public class NotifyHub:Hub
    //{
    //    public NotifyHub()//ICommunicationService communicationService)
    //    {

    //    }
    //    public async Task SendMessage(string message, string targetUserName)
    //    {
           
    //        //var userInfoSender = _userInfoInMemory.GetUserInfo(Context.User.Identity.Name);
    //        //var userInfoReciever = _userInfoInMemory.GetUserInfo(targetUserName);
    //        //return Clients.Client(userInfoReciever.ConnectionId).SendAsync("SendDM", message, userInfoSender);
    //    }

    //    public async Task ReceiveMessage(string message)
    //    {
    //        await Clients.All.SendMessage("BroadcastMessage", new MessageInfo()
    //        {

    //        };
    //    }
    //}
    public interface INotifyHub
    {
        Task SendMessage(string username, string message);
        Task ReceiveMessage(string message);
    }
   
}
