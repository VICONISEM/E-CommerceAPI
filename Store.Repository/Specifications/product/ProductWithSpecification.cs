using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specifications.product
{
    public  class ProductWithSpecification:BaseSpecification<Product>
    {
        public ProductWithSpecification(ProductSpecification specification):
            base(prod=>(!specification.BrandId.HasValue||prod.ProductBrandId==specification.BrandId.Value)&&
            (!specification.TypeId.HasValue||prod.ProductTypeId==specification.TypeId.Value))
            
            
        {
            AddInclude(x => x.ProductType);
            AddInclude(y => y.ProductBrand);
        }
    }
}
