using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatalError.Communication.Contracts
{
    public class MessageInfo
    {
        public string Message { get; set; }
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }


    }
}
