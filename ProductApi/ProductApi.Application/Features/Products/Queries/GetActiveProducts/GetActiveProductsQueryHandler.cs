using ProductApi.Application.Commons.Repositories;
using ProductApi.Application.Features.Products.DTOs;
using ProductApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Queries.GetActiveProducts
{
    public class GetActiveProductsQueryHandler : IGetActiveProductsQueryHandler
    {
        private readonly IProductRepository _productRepository;

        public GetActiveProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ActiveProductDto>> HandleAsync()
        {
            var activeProducts = await _productRepository.GetActiveProductsAsync();
            return MapToProductDto(activeProducts);
        }

        // =============================
        // Helper method for manuel mapping ProductList -> List<ProductDto>
        // =============================
        private List<ActiveProductDto> MapToProductDto(IEnumerable<Product> activeProducts)
        {
            return new List<ActiveProductDto>
            (
                activeProducts.Select(product => new ActiveProductDto
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock,
                    Category = product.Category,
                    IsActive = product.IsActive,
                })
            );
        }
    }
}
