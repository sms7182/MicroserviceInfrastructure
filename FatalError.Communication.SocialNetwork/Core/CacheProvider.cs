using FatalError.Communication.Contracts.CacheProvider;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FatalError.Communication.SocialNetwork.Core
{
    public class CacheProvider : ICacheProvider
    {
        IConnectionMultiplexer connectionMultiplexer;
        public CacheProvider(IConnectionMultiplexer _connectionMultiplexer)
        {
            connectionMultiplexer = _connectionMultiplexer;
        }
        public async Task<string> Get(string key)
        {
          var rediValue= await connectionMultiplexer.GetDatabase().StringGetAsync(key);

            return rediValue.ToString();
        }

        public void Set(string key, string value)
        {
            connectionMultiplexer.GetDatabase().StringSetAsync(key, value).Wait();
        }
    }
}
