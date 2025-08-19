using ProductApi.Application.Commons.Repositories;
using ProductApi.Application.Features.Products.DTOs;
using ProductApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : ICreateProductCommandHandler
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> HandleAsync(CreateProductCommand command)
        {
            var product = new ProductApi.Core.Entities.Product
            {
                Name = command._createProductDto.Name,
                Description = command._createProductDto.Description,
                Price = command._createProductDto.Price,
                Stock = command._createProductDto.Stock,
                Category = command._createProductDto.Category,
                ImageUrl = command._createProductDto.ImageUrl,
                IsActive = true, // Assuming new products are active by default
                CreatedAt = DateTime.UtcNow, // Set creation date to now
                Views = 0, // Initial views count
                Rating = 0.0, // Initial rating
            };

            await _productRepository.InsertAsync(product);

            // Map Product entity -> ProductDto for response
            var result = MapToProductDto(product);

            return result;
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
