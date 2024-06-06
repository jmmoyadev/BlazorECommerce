﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Shared
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }  
        public bool IsActive { get; set; }

        public IEnumerable<ProductProperty> Properties { get; set; } = Enumerable.Empty<ProductProperty>();

    }
}
