using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.DTOs.Product
{
    public class UpdateProductDto : CreateProductDto
    {
        public int ProductId { get; set; } // Product Id
        public DateTime? UpdatedAt { get; set; } // Last update time
    }
}
