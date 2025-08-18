using ProductApi.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Commands.Product
{
    public class CreateProductCommand
    {
        public CreateProductDto CreateProductDto { get; set; } // Input data

    }
}
