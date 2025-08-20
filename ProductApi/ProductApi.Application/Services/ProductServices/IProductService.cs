using ProductApi.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Services.ProductServices
{
    public interface IProductService
    {
        // Command Operations
        Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto);
        Task<ProductDto> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<bool> DeleteProductAsync(int productId);

        // Query Operations
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int productId);
        Task<List<ActiveProductDto>> GetActiveProductsAsync();
    }
}
