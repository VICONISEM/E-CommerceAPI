using AutoMapper;
using Store.Repository.Basket.Models;
using Store.Service.Services.Basket.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Basket.Mapper
{
    public class BasketProfile:Profile
    {
        public BasketProfile()
        {
            CreateMap<CustomerBasket, CustomerBasketDTO>().ReverseMap();

            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
        
        
        }
    }
}
