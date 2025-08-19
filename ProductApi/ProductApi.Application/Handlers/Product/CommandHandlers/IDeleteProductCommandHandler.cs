using ProductApi.Application.Commands.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Handlers.Product.CommandHandlers
{
    public interface IDeleteProductCommandHandler
    {
        Task<bool> HandleAsync(DeleteProductCommand command);
    }
}
