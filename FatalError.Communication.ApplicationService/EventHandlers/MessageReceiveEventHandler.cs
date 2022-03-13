using DotNetCore.CAP;
using FatalError.Communication.Contracts;
using FatalError.Communication.Domain;
using FatalError.Communication.Domain.Messages;
using FatalError.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FatalError.Communication.ApplicationService.EventHandlers
{
    public class MessageReceiveEventHandler: BaseEventHandler<MessageReceiveEvent>
    {
        

        
        readonly ICapPublisher capPublisher;
        readonly ICommunicationUnitOfWork communicationUnitOfWork;
        readonly IMessageMongoRepository messageMongoRepository;
        public MessageReceiveEventHandler(ICapPublisher _capPublisher,ICommunicationUnitOfWork _communicationUnitOfWork,IMessageMongoRepository _messageMongoRepository)
        {

            capPublisher = _capPublisher;
            communicationUnitOfWork = _communicationUnitOfWork;
            messageMongoRepository = _messageMongoRepository;
                

        }

        [CapSubscribe(nameof(MessageReceiveEvent))]
        public async Task Handle(MessageReceiveEvent receiveMessageEvent)
        {
           var message= new Message()
            {
                Id = Guid.NewGuid(),
                CreationDate = receiveMessageEvent.CreationDate,
                Descriptor = $"{receiveMessageEvent.Receiver} {receiveMessageEvent.Sender} ",
                MessageContent = receiveMessageEvent.Message,
                Receiver = receiveMessageEvent.Receiver,
                Sender = receiveMessageEvent.Sender,
                SocialNetworkType = receiveMessageEvent.SocialNetworkType

            };

          await  communicationUnitOfWork.MessageRepository.Add(message);
           await communicationUnitOfWork.CommitAsync();

           var messageReadmodel= new MessageDocument(message.Id,message.MessageContent,message.Sender,message.Receiver,message.SocialNetworkType);
          await  messageMongoRepository.InsertOneAsync(messageReadmodel);

            
        }
    }
}
