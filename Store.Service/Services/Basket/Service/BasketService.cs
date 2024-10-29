using AutoMapper;
using Store.Repository.Basket;
using Store.Repository.Basket.Models;
using Store.Service.Services.Basket.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Basket.Service
{
    public class BasketService:IBasketService
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _repository;
        public BasketService(IBasketRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;


        }

        public async Task<bool> DeleteBasketAsync(string BasketId)
       =>await _repository.DeleteBasketAsync(BasketId);

        public async Task<CustomerBasketDTO> GetBasketAsync(string Id)
        {
            var Basket =await _repository.GetBasketAsync(Id);
            if(Basket is not null)
            {
                var MappedBasket = _mapper.Map<CustomerBasketDTO>(Basket);
                return MappedBasket;

            }    
            else
            {
                return new CustomerBasketDTO();
            }
        }
       

        public async Task<CustomerBasketDTO> UpdateBasketAsync(CustomerBasketDTO customerBasket)
        {
            if (customerBasket is null)
            {
                customerBasket.Id = GenerateRandomId();
            }
            var CustBasket = _mapper.Map<CustomerBasket>(customerBasket);
            var UpdateBassket = await _repository.UpdateBasketAsync(CustBasket);
            var Mapped = _mapper.Map<CustomerBasketDTO>(UpdateBassket);
            return Mapped;
        }


        private string GenerateRandomId()
        {
            Random random = new Random();
            int RandDigit = random.Next(1000, 10000);
            return $"Bs-{RandDigit}";
    }
}
