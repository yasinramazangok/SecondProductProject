using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Commands.DeleteProduct
{
    public interface IDeleteProductCommandHandler
    {
        Task<bool> HandleAsync(DeleteProductCommand command);
    }
}
