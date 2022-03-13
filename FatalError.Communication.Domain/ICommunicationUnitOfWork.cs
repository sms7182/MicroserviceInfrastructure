using FatalError.Core.DataAccess.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Domain
{
    public interface ICommunicationUnitOfWork:IBaseWriteUnitOfWork
    {
        IMessageRepository MessageRepository { get; }
    }
}
