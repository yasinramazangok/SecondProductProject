using ProductApi.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Commands.CreateProduct
{
    public interface ICreateProductCommandHandler
    {
        Task<ProductDto> HandleAsync(CreateProductCommand command);
    }
}
