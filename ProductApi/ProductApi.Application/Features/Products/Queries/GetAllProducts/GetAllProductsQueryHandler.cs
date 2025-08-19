using ProductApi.Application.Commons.Repositories;
using ProductApi.Application.Features.Products.DTOs;
using ProductApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IGetAllProductsQueryHandler
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> HandleAsync()
        {
            var products = await _productRepository.GetAllAsync();
            
            return MapToProductDto(products);
        }

        // =============================
        // Helper method for manuel mapping ProductList -> List<ProductDto>
        // =============================
        private List<ProductDto> MapToProductDto(IEnumerable<Product> productList)
        {
            return new List<ProductDto>
            (
                productList.Select(product => new ProductDto
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
                })
            );
        }
    }
}
