using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Models
{
    public class ApplicationUser: IdentityUser         //<!--lecture7   2:52-->
    {
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string postalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }


    }
}
