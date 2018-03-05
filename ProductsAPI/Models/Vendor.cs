using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsAPI.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
    }
}