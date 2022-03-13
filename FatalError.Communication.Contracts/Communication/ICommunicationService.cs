
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FatalError.Communication.Contracts
{
    public interface ICommunicationService
    {
        Task SendMessage(string userName, string message);
        Task BroadcastMessage(MessageInfo messageInfo);
    }
}
