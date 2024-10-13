using Store.DAL.Entities;
using Store.Repository.Interfaces;
using Store.Service.Services.Products.DTOs;
using Store.Service.Services.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products.Service
{
    public class ProductService:IProductService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BrandTypeDTOs>> GetAllBrandsAsync()
        {
           
         var brands =await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();
            IReadOnlyList<BrandTypeDTOs> MappedBrands = brands.Select(b => new BrandTypeDTOs 
            {   Id = b.Id,
                Name = b.Name,
                CreatedAt = b.CreatedAt 
            }).ToList();

            return MappedBrands;
           
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products=await _unitOfWork.Repository<Product,int>().GetAllAsync();

            IReadOnlyList<ProductDto> MaapedProducts = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                BrandName = p.ProductBrand.Name,
                CreatedAt = p.CreatedAt,
                Description = p.Description,
                PictureUrl = p.ImageUrl,
                Price = p.Price,
                TypeName = p.ProductType.Name

            }).ToList();

            return MaapedProducts;


            
        }

        public async Task<IEnumerable<BrandTypeDTOs>> GetAllTypesAsync()
        {
            var Types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
            IReadOnlyList<BrandTypeDTOs> MappedTypes = Types.Select(T => new BrandTypeDTOs
            {
                Id=T.Id,
                Name = T.Name,
                CreatedAt=T.CreatedAt
            }).ToList();
            return MappedTypes;
        }

        public async Task<ProductDto> GetByIdAsync(int Id)
        {
           var Product=await _unitOfWork.Repository<Product,int>().GetByIdAsync(Id);
            return new ProductDto { 
                Id=Product.Id,
                Name=Product.Name,
                CreatedAt=Product.CreatedAt,
                Description=Product.Description,
                BrandName=Product.ProductBrand.Name,
                Price=Product.Price,
                TypeName=Product.ProductType.Name,
                PictureUrl=Product.ImageUrl
                
                
               
            };

        }
    }
}
