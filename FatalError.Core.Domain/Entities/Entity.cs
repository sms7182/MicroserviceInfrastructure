using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Core.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreationDate { get; set; }
        string Descriptor { get; set; }
        bool IsDeleted { get; set; }
    }

    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            
                
        }
        [BsonElement("id")]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("creationDate")]
        public DateTime CreationDate { get; set; }

        [BsonElement("descriptor")]
        public string Descriptor { get; set; }


        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; }
    }
}
