using ProductApi.Application.Commons.Repositories;
using ProductApi.Application.Features.Products.DTOs;
using ProductApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IUpdateProductCommandHandler
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> HandleAsync(UpdateProductCommand command)
        {
            var existingProduct = await _productRepository.GetByIdAsync(command._updateProductDto.ProductId);
            if (existingProduct == null)
                throw new InvalidOperationException($"ID'si {command._updateProductDto.ProductId} olan ürün bulunamadı!");

            // Update the product properties
            existingProduct.Name = command._updateProductDto.Name;
            existingProduct.Description = command._updateProductDto.Description;
            existingProduct.Price = command._updateProductDto.Price;
            existingProduct.Stock = command._updateProductDto.Stock;
            existingProduct.Category = command._updateProductDto.Category;
            existingProduct.ImageUrl = command._updateProductDto.ImageUrl;
            existingProduct.IsActive = command._updateProductDto.IsActive;
            existingProduct.UpdatedAt = DateTime.UtcNow;

            await _productRepository.UpdateAsync(existingProduct);

            // Map Product entity -> ProductDto for response
            var result = MapToProductDto(existingProduct);

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
