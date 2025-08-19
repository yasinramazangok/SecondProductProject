using ProductApi.Application.Commands.Product;
using ProductApi.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Handlers.Product.CommandHandlers
{
    public interface ICreateProductCommandHandler
    {
        Task<ProductDto> HandleAsync(CreateProductCommand command);
    }
}
