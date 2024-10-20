﻿using Store.Repository.Specifications.product;
using Store.Service.Services.Products.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products.Interfaces
{
    public interface IProductService
    {
        public Task<ProductDto> GetByIdAsync(int ?Id);

        public Task<PaginatedResultDto<ProductDto>>GetAllProductsAsync(ProductSpecification specs);
        public Task<IEnumerable<BrandTypeDTOs>> GetAllBrandsAsync();
        public Task<IEnumerable<BrandTypeDTOs>> GetAllTypesAsync();



    }
}
