using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Entities
{
    public class ProductType:BaseEntity<int>
    {

        public string Name { get; set; }


        public List<Product> Products { get; set; }
    }
}
