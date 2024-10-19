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
            AddOrderByAsc(z => z.Name);
            ApplayPagination(specification._PageSize * (specification.pageIndex - 1), specification._PageSize);
            if(!string.IsNullOrEmpty(specification.Sort))
            {
                switch (specification.Sort)
                {
                    case "PriceAsc":
                      AddOrderByAsc(x => x.Price);
                        break;

                    case "PriceDesc":
                        AddOrderByDesc(x => x.Price);
                        break;

                    default:
                        AddOrderByAsc(z => z.Name);
                        break;
                };
            }
        }

        public ProductWithSpecification(int ?Id) :base(p=>p.Id==Id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(y => y.ProductType);
        }
         
    }
}
