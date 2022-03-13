using FatalError.Communication.Domain;
using FatalError.Communication.Domain.Messages;
using FatalError.Core.Data.Configuration;
using FatalError.Core.Data.MongoDataInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Data.Repositories.NoSqlRepository
{
    public class MessageMongoRepository : MongoRepository<MessageDocument>, IMessageMongoRepository
    {
        public MessageMongoRepository(IMongoDbSettings mongoDbSettings) : base(mongoDbSettings)
        {

        }
    }
}
