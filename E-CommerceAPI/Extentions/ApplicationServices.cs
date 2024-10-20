using Store.Repository.Interfaces;
using Store.Repository.UnitofWork;
using Store.Service.Services.Products.Interfaces;
using Store.Service.Services.Products.Mapper;
using Store.Service.Services.Products.Service;

namespace E_CommerceAPI.Extentions
{
    public static class ApplicationServices
    {
        public static IServiceCollection ApplicationService(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddScoped<IProductService, ProductService>();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen();
            return services;
        }
    }
}
