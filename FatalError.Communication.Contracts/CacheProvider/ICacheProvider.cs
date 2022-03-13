using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FatalError.Communication.Contracts.CacheProvider
{
    public interface ICacheProvider
    {
        void Set(string key, string value);
        Task<string> Get(string key);
    }
}
