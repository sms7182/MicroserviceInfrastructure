using FatalError.Communication.Data.Repositories;
using FatalError.Communication.Domain;
using FatalError.Core.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Data.Configuration
{
    public class CommunicationUnitOfWork : BaseWriteUnitOfWork,ICommunicationUnitOfWork
    {
        public CommunicationUnitOfWork(WriteApplicationDBContext applicationDBContext,IServiceProvider serviceProvider):base(applicationDBContext,serviceProvider)
        {
        
        }

        IMessageRepository messageRepository;
        public IMessageRepository MessageRepository { get { return messageRepository ??= new MessageRepository(DbContext()); } }
    }
}
