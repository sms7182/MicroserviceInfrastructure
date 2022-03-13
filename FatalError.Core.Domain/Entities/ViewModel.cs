using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Core.Domain.Entities
{
    public abstract class ViewModel:Entity,IEntity
    {
        public ViewModel(Guid id,DateTime creationDate,string descriptor,bool isDeleted=false)
        {
            Id = id;
            CreationDate = creationDate;
            Descriptor = descriptor;
            IsDeleted = isDeleted;
            
        }
    }
}
