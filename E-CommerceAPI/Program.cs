using E_CommerceAPI.Extensions;
using E_CommerceAPI.Extentions;
using E_CommerceAPI.Helper;
using E_CommerceAPI.MiddelWare;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Store.DAL.Contexts;
using Store.DAL.Entities.IdentityEntity;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Register StoreDbcontext
        builder.Services.AddDbContext<StoreDbcontext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Register IdentityDbContext for identity
        builder.Services.AddDbContext<IdentityDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityCS")));

        // Identity registration
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.AddSingleton<IConnectionMultiplexer>(config =>
        {
            var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"));
            return ConnectionMultiplexer.Connect(configuration);
        });

        builder.Services.ApplicationService();
        builder.Services.ApplyIdentityServices();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseMiddleware<ExceptionMiddelWare>();
        app.UseAuthorization();
        app.UseStaticFiles();

        await ApplaySeedingAsync.ApplaySeeding(app);

        app.MapControllers();
        app.Run();
    }
}
