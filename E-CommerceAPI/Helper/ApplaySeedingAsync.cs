using Store.DAL.Contexts;

namespace E_CommerceAPI.Helper
{
    public class ApplaySeedingAsync
    {

        public static async Task ApplaySeeding(WebApplication app)
        {
            using (var scope =app.Services.CreateScope())
            {
                var service=scope.ServiceProvider;
                var loggerfactory=service.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = service.GetRequiredService<StoreDbcontext>();
                    await StoreDbContextSeed.SeedAsync(context, loggerfactory);
                }
                catch (Exception ex) { }
            }

        }
    }
}
