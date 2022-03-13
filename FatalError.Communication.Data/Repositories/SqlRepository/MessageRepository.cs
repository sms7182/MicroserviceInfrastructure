using FatalError.Communication.Domain;
using FatalError.Communication.Domain.Messages;
using FatalError.Core.Data.Configuration;
using FatalError.Core.Data.MongoDataInfrastructure;
using FatalError.Core.Data.Reppositories;
using FatalError.Core.DataAccess.Repositories;
using FatalError.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FatalError.Communication.Data.Repositories
{
   
   
    public class MessageRepository : EntityRepository<Message>, IMessageRepository
    {
        public MessageRepository(DbContext dbContext):base(dbContext)
        {

        }
    }

  
 

}
