using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Store.Service.Services.Products.CachServices;
using System.Text;

namespace E_CommerceAPI.Helper
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {

        private int _Time;
        public CacheAttribute(int TimeToLive) {
        
        _Time = TimeToLive;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var CacheService = context.HttpContext.RequestServices.GetRequiredService<ICachService>();
            var CaheKey = GenerateCashedKeyFromRequest(context.HttpContext.Request);
            var CacheResponse=await CacheService.GetCachResponseAsync(CaheKey);
            if (!string.IsNullOrEmpty(CacheResponse))
            {
                var ContentResult = new ContentResult()
                {
                    Content = CacheResponse,
                    ContentType="application/json",
                    StatusCode=200
                };
                context.Result = ContentResult;
            }
            var Next = await next();
            if(Next.Result is OkObjectResult Res)
            {
                await CacheService.SetCachResponseAsync(CaheKey, Res.Value, TimeSpan.FromSeconds(_Time));
            }
        }
        private string GenerateCashedKeyFromRequest(HttpRequest context)
        {
            StringBuilder CacheKey= new StringBuilder();
            CacheKey.Append($"{context.Path}");
            foreach(var(key,value) in context.Query.OrderBy(x=>x.Key))
            {
                CacheKey.Append($"{key}-{value}");
            }
            return CacheKey.ToString(); 
        }
    }
}
