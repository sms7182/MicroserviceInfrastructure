using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Core.DataAccess.Mongo
{
    [AttributeUsage(AttributeTargets.Class,Inherited =false)]
    public class BsonCollection:Attribute
    {
        public string CollectionName { get;  }
        public BsonCollection(string collection)
        {
            CollectionName = collection;
        }
    }
}
