using DotNetCore.CAP;
using FatalError.Communication.Contracts;
using FatalError.Communication.Domain;
using FatalError.Communication.Domain.Messages;
using FatalError.Core.ApplicationService;
using FatalError.Core.CAP;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FatalError.Communication.ApplicationService.EventHandlers
{
    public class SendMessageEventHandler:BaseEventHandler<SendMessageEvent>
    {


        readonly ICapPublisher capPublisher;
        readonly ICommunicationUnitOfWork communicationUnitOfWork;
        readonly IMessageMongoRepository messageMongoRepository;
        public SendMessageEventHandler(ICapPublisher _capPublisher, ICommunicationUnitOfWork _communicationUnitOfWork, IMessageMongoRepository _messageMongoRepository)
        {

            capPublisher = _capPublisher;
            communicationUnitOfWork = _communicationUnitOfWork;
            messageMongoRepository = _messageMongoRepository;


        }

        [CapSubscribe(nameof(SendMessageEvent))]
        public async Task Handle(SendMessageEvent sendMessageEvent)
        {
            var message = new Message()
            {
                Id = Guid.NewGuid(),
                CreationDate = sendMessageEvent.CreationDate,
                Descriptor = $"{sendMessageEvent.Receiver} {sendMessageEvent.Sender} ",
                MessageContent = sendMessageEvent.Message,
                Receiver = sendMessageEvent.Receiver,
                Sender = sendMessageEvent.Sender,
                SocialNetworkType = sendMessageEvent.SocialNetworkType

            };

            await communicationUnitOfWork.MessageRepository.Add(message);
            await communicationUnitOfWork.CommitAsync();

            var messageReadmodel = new MessageDocument(message.Id, message.MessageContent, message.Sender, message.Receiver, message.SocialNetworkType);
           var id= messageMongoRepository.Id;
            await messageMongoRepository.InsertOneAsync(messageReadmodel);

        }
    }

    
  
}
