using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Image> Images { get; set; }
    }
}
