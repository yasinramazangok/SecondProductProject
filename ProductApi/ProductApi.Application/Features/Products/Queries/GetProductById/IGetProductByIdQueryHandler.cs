using ProductApi.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Queries.GetProductById
{
    public interface IGetProductByIdQueryHandler
    {
        Task<ProductDto?> HandleAsync(GetProductByIdQuery query);
    }
}
