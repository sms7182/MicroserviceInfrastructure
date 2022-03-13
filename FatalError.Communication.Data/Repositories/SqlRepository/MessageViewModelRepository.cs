using FatalError.Communication.Domain;
using FatalError.Communication.Domain.Messages.ReadModel;
using FatalError.Core.Data.Reppositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Data.Repositories.SqlRepository
{
    class MessageViewModelRepository: ReadRepository<MessageViewModel>, IMessageViewModelRepository
    {
        public MessageViewModelRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
