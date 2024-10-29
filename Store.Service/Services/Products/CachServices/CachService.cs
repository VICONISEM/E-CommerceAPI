using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Service.Services.Products.CachServices
{
    public class CachService : ICachService
    {
        private readonly IDatabase _connection;
        public CachService(IConnectionMultiplexer connection)
        {
            _connection = connection.GetDatabase();

        }

        public async Task<string?> GetCachResponseAsync(string Key)
        {
            var CachedResponse = await _connection.StringGetAsync(Key);
            if(string.IsNullOrEmpty(CachedResponse))
            {
                return null;
            }
           
                return CachedResponse.ToString();
            
        }

        public async Task SetCachResponseAsync(string Key, object Response, TimeSpan TimeToLive)
        {
            if(Response is null)
            {
                return;
            }

            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var serialized=JsonSerializer.Serialize(Response, options);
            await _connection.StringSetAsync(Key, serialized,TimeToLive);


           
        }
    }
}
