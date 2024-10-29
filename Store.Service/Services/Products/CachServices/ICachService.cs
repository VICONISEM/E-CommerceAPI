using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products.CachServices
{
    public interface ICachService
    {
        Task SetCachResponseAsync(string Key, object Response, TimeSpan TimeToLive);

        Task<string> GetCachResponseAsync(string Key);

    }
}
