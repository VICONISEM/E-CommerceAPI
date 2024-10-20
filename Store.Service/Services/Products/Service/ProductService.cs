using AutoMapper;
using Store.DAL.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Specifications.product;
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

        public async Task<PaginatedResultDto<ProductDto>> GetAllProductsAsync(ProductSpecification input)
        {
            var specs = new ProductWithSpecification(input);
            var products=await _unitOfWork.Repository<Product,int>().GetAllWithSpecificationAsync(specs);

            IReadOnlyList<ProductDto> MaapedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);

            var countSpecs=new ProductWithCountSpecification(input);
            var count=await _unitOfWork.Repository<Product, int>().GetCountWithspecs(countSpecs);


            return new PaginatedResultDto<ProductDto>(input.pageIndex,input._PageSize, count, MaapedProducts) {};


            
        }
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            
            var products = await _unitOfWork.Repository<Product, int>().GetAllAsync();

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
            var specs=new ProductWithSpecification(Id);
            var Product = await _unitOfWork.Repository<Product, int>().GetByIdWithSpecificationAsync(specs);
            return _mapper.Map<ProductDto>(Product);

        }

     
    }
}
