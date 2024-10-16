using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Specifications.product;
using Store.Service.Services.Products.DTOs;
using Store.Service.Services.Products.Interfaces;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService service)
        {
            _productService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDTOs>>> GetAllBrands()
        {
            var Brands = await _productService.GetAllBrandsAsync();

            return Ok(Brands);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDTOs>>> GetAllTypes()
        {
            var Types = await _productService.GetAllTypesAsync();

            return Ok(Types);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAllProducts([FromQuery]ProductSpecification input)
        {
            var Products = await _productService.GetAllProductsAsync(input);
            return Ok(Products);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>>GetProductById(int ? id)
        {
            if(id is not null)
            {
                var product = await _productService.GetByIdAsync(id.Value);
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
