using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Core.Data.Configuration
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
