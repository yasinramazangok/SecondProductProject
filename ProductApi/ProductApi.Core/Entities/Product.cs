using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Core.Entities
{
    public class Product
    {
        public int ProductId { get; set; }                  // Primary key
        public string Name { get; set; }                    // Product name
        public string Description { get; set; }             // Description
        public decimal Price { get; set; }                  // Price
        public int Stock { get; set; }                      // Stock quantity
        public string Category { get; set; }                // Product category
        public string ImageUrl { get; set; }                // Product image URL
        public bool IsActive { get; set; }                  // Is product active?
        public DateTime CreatedAt { get; set; }             // Creation date
        public DateTime? UpdatedAt { get; set; }            // Last update time
        public int Views { get; set; } = 0;                 // View count
        public double Rating { get; set; } = 0.0;           // Average rating
    }
}
