﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsAPI.Models
{
    public class ProductDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public string Address { get; set; }


    }
}