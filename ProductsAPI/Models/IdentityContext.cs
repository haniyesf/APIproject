using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsAPI.Models
{
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {

        public IdentityContext(): base("MyConnection")
        {

        }


    }
}