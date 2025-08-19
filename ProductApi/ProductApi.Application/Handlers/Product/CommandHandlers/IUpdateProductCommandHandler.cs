using ProductApi.Application.Commands.Product;
using ProductApi.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Handlers.Product.CommandHandlers
{
    public interface IUpdateProductCommandHandler
    {
        Task<ProductDto> HandleAsync(UpdateProductCommand command);
    }
}
