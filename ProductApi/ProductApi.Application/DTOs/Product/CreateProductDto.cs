using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.DTOs.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }        // Product name
        public string Description { get; set; } // Description
        public decimal Price { get; set; }      // Price
        public int Stock { get; set; }          // Stock quantity
        public string Category { get; set; }    // Category
        public string ImageUrl { get; set; }    // Image URL
        public bool IsActive { get; set; } = true; // Is product active
    }
}
