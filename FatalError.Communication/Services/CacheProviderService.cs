using FatalError.Communication.Contracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FatalError.Communication.Services
{
    public class CacheProviderService:ICacheProviderService
    {
        private static ConcurrentDictionary<string,string> Dictionary { get; set; }

        public CacheProviderService()
        {
            Dictionary = new ConcurrentDictionary<string, string>();
        }
        public string Get(string key)
        {
            var hasValue = Dictionary.TryGetValue(key, out var value);
            return value;
        }

        public bool Set(string key,string value)
        {
          return  Dictionary.TryAdd(key, value);
        }

    }
}
