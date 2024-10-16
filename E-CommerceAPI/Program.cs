
using E_CommerceAPI.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Store.DAL.Contexts;
using Store.Repository.Interfaces;
using Store.Repository.UnitofWork;
using Store.Service.Services.Products.Interfaces;
using Store.Service.Services.Products.Mapper;
using Store.Service.Services.Products.Service;

namespace E_CommerceAPI
{
    public class Program
    {
        public static async Task  Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(ProductProfile));
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();
            await ApplaySeedingAsync.ApplaySeeding(app);

            app.MapControllers();

            app.Run();
        }
    }
}
