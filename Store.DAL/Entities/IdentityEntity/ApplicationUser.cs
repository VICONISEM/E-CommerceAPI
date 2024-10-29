using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Entities.IdentityEntity
{
    public  class ApplicationUser:IdentityUser
    {
        public string DisplayName { get; set; }

        public Address address { get; set; }


    }
}
