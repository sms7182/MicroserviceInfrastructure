using FatalError.Communication.Contracts;
using FatalError.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Domain.Messages
{
    public class Message:AggregateEntity,IEntity
    {
        public string MessageContent { get;  set; }
        public string Sender { get;  set; }
        public string Receiver { get;  set; }
        public SocialNetworkType SocialNetworkType { get; set; }
    }
}
