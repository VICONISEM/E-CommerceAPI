using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Entities
{
    public  class BaseEntity<T>
    {
        public T Id { get; set; }

        public DateTime CreatedAt { get; set; }=DateTime.Now;

        public bool IsDeleted { get; set; }


 

    }
}
