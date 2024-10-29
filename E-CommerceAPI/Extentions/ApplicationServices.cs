using Microsoft.Extensions.Options;
using StackExchange.Redis;
using Store.Repository.Basket;
using Store.Repository.Interfaces;
using Store.Repository.UnitofWork;
using Store.Service.Services.Basket.Mapper;
using Store.Service.Services.Basket.Service;
using Store.Service.Services.Products.CachServices;
using Store.Service.Services.Products.Interfaces;
using Store.Service.Services.Products.Mapper;
using Store.Service.Services.Products.Service;

namespace E_CommerceAPI.Extentions
{
    public static class ApplicationServices
    {
        public static void ApplicationService(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddScoped<IProductService, ProductService>();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen();
            services.AddSingleton<ICachService, CachService>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddAutoMapper(typeof(BasketProfile));

           
        }
    }
}
