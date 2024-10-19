using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specifications.product
{
    public class ProductSpecification
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }


        public string ? Sort { get; set; }

        public int pageIndex { get; set; }

        private int PageSize;
        public const int MAXPAGESIZE = 50;
        public int _PageSize
        {
            get => PageSize;
            set => PageSize = (value > MAXPAGESIZE )? value : MAXPAGESIZE;


        }
        private string? _Search;

        public string? Search
        {
            get => _Search;
            set => _Search = value?.Trim().ToLower();
        }


    }
}
