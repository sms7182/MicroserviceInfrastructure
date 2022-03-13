using FatalError.Communication.Data.Repositories.SqlRepository;
using FatalError.Communication.Domain;
using FatalError.Core.Data.UnitOfWorks;
using FatalError.Core.DataAccess.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Data.Configuration
{
    public class CommunicationReadUnitOfWork: BaseUnitOfWork,ICommunicationReadUnitOfWork
    {
        public CommunicationReadUnitOfWork(ReadApplicationDBContext readApplicationDBContext,IServiceProvider _serviceProvider):base(readApplicationDBContext,_serviceProvider)
        {
            
        }
        IMessageViewModelRepository messageRepository;
        public IMessageViewModelRepository MessageRepository { get { return messageRepository ??= new MessageViewModelRepository(DbContext()); } }
    }
}
