using FatalError.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Contracts
{
    public class MessageReceiveEvent:Event
    {
        public MessageReceiveEvent()
        {
            Id = Guid.NewGuid();
        }
        public long ChatId { get; set; }
        public Guid Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
        public SocialNetworkType SocialNetworkType { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
