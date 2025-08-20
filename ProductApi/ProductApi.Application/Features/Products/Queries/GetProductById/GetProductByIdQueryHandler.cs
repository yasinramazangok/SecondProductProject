using ProductApi.Application.Commons.Repositories;
using ProductApi.Application.Features.Products.DTOs;
using ProductApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IGetProductByIdQueryHandler
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto?> HandleAsync(GetProductByIdQuery query)
        {
            var product = await _productRepository.GetByIdAsync(query.ProductId);

            return product != null ? MapToProductDto(product) : null;
        }

        // =============================
        // Helper method for manuel mapping Product -> ProductDto
        // =============================
        private ProductDto MapToProductDto(Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Category = product.Category,
                ImageUrl = product.ImageUrl,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                Views = product.Views,
                Rating = product.Rating
            };
        }
    }
}
