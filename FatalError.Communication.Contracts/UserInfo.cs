using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FatalError.Communication.Contracts
{
    public class UserInfo
    {
        public UserInfo()
        {
            UserId = Guid.NewGuid();
                
        }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public SocialNetworkType SocialType { get; set; }
        public long ChatId { get; set; }
    }
    public enum SocialNetworkType
    {
        Telegram=0,
        Instagram=1,
        WhatsApp=2
    }
}
