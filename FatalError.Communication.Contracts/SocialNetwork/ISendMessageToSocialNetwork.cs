using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatalError.Communication.Contracts.SocialNetwork
{
    public interface ISendMessageToSocialNetwork
    {
        Task SendToTelegram(long chatId, string username,string message);
    }
}
