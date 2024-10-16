using AutoMapper;
using Microsoft.Extensions.Options;
using Store.DAL.Entities;
using Store.Service.Services.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products.Mapper
{
    public  class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(PDTO=>PDTO.BrandName,option=>option.MapFrom(P=>P.ProductBrand.Name))
                .ForMember(PDTO=>PDTO.TypeName,option=>option.MapFrom(p=>p.ProductType.Name))
                .ForMember(PDTO=>PDTO.PictureUrl,option=>option.MapFrom(p=>p.ImageUrl));

            CreateMap<ProductBrand, BrandTypeDTOs>();
            CreateMap<ProductType, BrandTypeDTOs>();


        }
    }
}
