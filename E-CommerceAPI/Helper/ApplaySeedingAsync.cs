using Microsoft.AspNetCore.Identity;
using Store.DAL.Contexts;
using Store.DAL.Entities.IdentityEntity;

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
                    var UserSeeding = service.GetRequiredService<UserManager<ApplicationUser>>();
                    var context = service.GetRequiredService<StoreDbcontext>();
                    await StoreDbContextSeed.SeedAsync(context, loggerfactory);
                    await SeedingIdentity.SeedUserAsync(UserSeeding);
                }
                catch (Exception ex) { }
            }

        }
    }
}
