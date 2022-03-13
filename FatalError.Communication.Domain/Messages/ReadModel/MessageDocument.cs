using FatalError.Communication.Contracts;
using FatalError.Core.DataAccess.Mongo;
using FatalError.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Domain.Messages
{
   
    [BsonCollection("messages")]
    public class MessageDocument:Document
    {
        public MessageDocument(Guid id,string message,string sender,string receiver,SocialNetworkType socialNetworkType)
        {
            Id = id;
            Descriptor = $"{nameof(MessageDocument)} from {sender} to {receiver} with {socialNetworkType}";
            MessageContent = message;
            Sender = sender;
            Receiver = receiver;
            SocialNetworkType = socialNetworkType;
        }
        public string MessageContent { get; private set; }
        public string Sender { get; private set; }
        public string Receiver { get; private set; }
        public SocialNetworkType SocialNetworkType { get;private set; }
    }
}
