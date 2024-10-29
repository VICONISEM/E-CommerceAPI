using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store.DAL.Entities.IdentityEntity;

namespace E_CommerceAPI.Extensions
{
    public static class IdentityServices
    {
        public static IServiceCollection ApplyIdentityServices(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApplicationUser>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<IdentityDbContext>();
            builder.AddSignInManager<SignInManager<ApplicationUser>>();
            services.AddAuthentication();
            return services;
        }
    }
}
