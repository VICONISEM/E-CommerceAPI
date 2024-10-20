using Store.Service.HandelResponse;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace E_CommerceAPI.MiddelWare
{
    public class ExceptionMiddelWare
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddelWare> logger;
        private readonly IHostEnvironment environment;

        public ExceptionMiddelWare(RequestDelegate Next,ILogger<ExceptionMiddelWare> logger,IHostEnvironment environment)
        {
            next = Next;
            this.logger = logger;
            this.environment = environment;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var ResponseEnv = environment.IsDevelopment()?new CostumException(500,ex.Message,ex.StackTrace.ToString()):new CostumException((int)HttpStatusCode.InternalServerError);

                var option = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy= JsonNamingPolicy.CamelCase

                };
                var JsonResponse=JsonSerializer.Serialize(ResponseEnv,option);
                await context.Response.WriteAsync(JsonResponse);

            }
        }


    }
}
