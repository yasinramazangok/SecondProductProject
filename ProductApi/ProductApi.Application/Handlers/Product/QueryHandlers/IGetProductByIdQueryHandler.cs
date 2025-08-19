using ProductApi.Application.DTOs.Product;
using ProductApi.Application.Queries.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Handlers.Product.QueryHandlers
{
    public interface IGetProductByIdQueryHandler
    {
        Task<ProductDto?> HandleAsync(GetProductByIdQuery query);
    }
}
