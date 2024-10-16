using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BrandTypeDTOs>> GetAllBrandsAsync()
        {
           
         var brands =await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();
            IReadOnlyList<BrandTypeDTOs> MappedBrands = _mapper.Map<IReadOnlyList<BrandTypeDTOs>>(brands);
            return MappedBrands;
           
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products=await _unitOfWork.Repository<Product,int>().GetAllAsync();

            IReadOnlyList<ProductDto> MaapedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);

            return MaapedProducts;


            
        }

        public async Task<IEnumerable<BrandTypeDTOs>> GetAllTypesAsync()
        {
            var Types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
            IReadOnlyList<BrandTypeDTOs> MappedTypes = _mapper.Map<IReadOnlyList<BrandTypeDTOs>>(Types);
            return MappedTypes;
        }

        public async Task<ProductDto> GetByIdAsync(int? Id)
        {
           var Product=await _unitOfWork.Repository<Product,int>().GetByIdAsync(Id.Value);
            return _mapper.Map<ProductDto>(Product);

        }
    }
}
