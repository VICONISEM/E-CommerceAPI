using Microsoft.AspNetCore.Identity;
using Store.DAL.Entities.IdentityEntity;

namespace E_CommerceAPI.Helper
{
    public class SeedingIdentity
    {
        public static async Task SeedUserAsync(UserManager<ApplicationUser> User)
        {
            if(!User.Users.Any())
            {
                var U = new ApplicationUser()
                {
                    DisplayName = "Victor Nisem",
                    Email = "victornisem@gmail.com",
                    UserName = "Vico",
                    address = new List<Address>() { new Address() { FirstName = "Victor", LastName = "Nisem", State = "Egypt", } }



                };
                await User.CreateAsync(U,"Vico1234");
            }
        }
    }
}
