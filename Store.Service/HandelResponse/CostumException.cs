using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.HandelResponse
{
    public class CostumException:Response
    {
     

        public CostumException(int statusCode, string? Message=null, string? detalis=null):base(statusCode,Message)
        {
            Details = detalis;
        }

        public string? Details { get; set; }


    }
}
