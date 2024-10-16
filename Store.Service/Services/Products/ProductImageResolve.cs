using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Store.DAL.Entities;
using Store.Service.Services.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products
{
    public class ProductImageResolve : IValueResolver<Product, ProductDto, string>
    {
        private readonly IHttpContextAccessor _configuration;
        public ProductImageResolve(IHttpContextAccessor configuration)
        {
            _configuration = configuration;
        }

        
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ImageUrl))
            {
                var request=_configuration.HttpContext.Request;
                return $"{request.Scheme}://{request.Host}/{source.ImageUrl}";

            }
            return null;
        }
    }
}
