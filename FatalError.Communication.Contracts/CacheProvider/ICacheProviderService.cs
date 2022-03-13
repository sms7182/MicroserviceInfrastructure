using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FatalError.Communication.Contracts
{
    public interface ICacheProviderService
    {
        bool Set(string key, string value);
        string Get(string key);
    }
}
