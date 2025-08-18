using ProductApi.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Commands.Product
{
    public class UpdateProductCommand
    {
        public UpdateProductDto UpdateProductDto { get; set; } // Input data

    }
}
