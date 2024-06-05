﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Create
{
    public class CreateProductDTO
    {
        public string Title { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }
    }
}
