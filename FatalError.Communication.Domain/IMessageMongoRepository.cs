using FatalError.Communication.Domain.Messages;
using FatalError.Core.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Domain
{
    public interface IMessageMongoRepository:IMongoRepository<MessageDocument>
    {

    }
}
