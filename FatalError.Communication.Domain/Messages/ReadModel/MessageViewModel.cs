using FatalError.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Domain.Messages.ReadModel
{
    public class MessageViewModel:ViewModel
    {
        public MessageViewModel(Guid id, DateTime creationDate, string descriptor, bool isDeleted = false):base(id,creationDate,descriptor,isDeleted)
        {

        }
    }
}
