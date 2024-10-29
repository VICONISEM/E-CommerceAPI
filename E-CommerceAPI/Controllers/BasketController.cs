using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Service.Services.Basket.DTO;
using Store.Service.Services.Basket.Service;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasketDTO>> GetBasketAsync(string id)
            => Ok(await _basketService.GetBasketAsync(id));

        [HttpPost]
        public async Task<ActionResult<CustomerBasketDTO>> UpdateBasketAsync( CustomerBasketDTO Basket)
        {
            return Ok(await _basketService.UpdateBasketAsync(Basket));
        }

        [HttpDelete("{id}")]

        public  async Task<ActionResult> DeleteBasketAsync(string id)
            =>Ok(await _basketService.DeleteBasketAsync(id));

    }
}
