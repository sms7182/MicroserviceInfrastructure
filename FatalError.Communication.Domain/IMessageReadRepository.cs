using FatalError.Communication.Domain.Messages.ReadModel;
using FatalError.Core.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Domain
{
    public interface IMessageViewModelRepository : IReadRepository<MessageViewModel>
    {
    }
}
