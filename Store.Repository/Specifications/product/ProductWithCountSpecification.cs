using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specifications.product
{
    public  class ProductWithCountSpecification:BaseSpecification<Product>
    {

        public ProductWithCountSpecification(ProductSpecification specs) :  base(prod=>(!specs.BrandId.HasValue||prod.ProductBrandId== specs.BrandId.Value)&&
            (!specs.TypeId.HasValue||prod.ProductTypeId==specs.TypeId.Value) &&
            (string.IsNullOrEmpty(specs.Search) || prod.Name.Trim().ToLower().Contains(specs.Search)))
        { }
    }
}
