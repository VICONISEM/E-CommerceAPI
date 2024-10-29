using Store.Repository.Basket.Models;
using Store.Service.Services.Basket.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Basket.Service
{
    public  interface IBasketService
    {

        Task<CustomerBasketDTO> GetBasketAsync(string Id);
        Task<CustomerBasketDTO> UpdateBasketAsync(CustomerBasketDTO customerBasket);

        Task<bool> DeleteBasketAsync(string BasketId);




    }




}

