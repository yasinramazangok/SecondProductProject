using ProductApi.Application.Features.Products.Commands.CreateProduct;
using ProductApi.Application.Features.Products.Commands.DeleteProduct;
using ProductApi.Application.Features.Products.Commands.UpdateProduct;
using ProductApi.Application.Features.Products.DTOs;
using ProductApi.Application.Features.Products.Queries.GetActiveProducts;
using ProductApi.Application.Features.Products.Queries.GetAllProducts;
using ProductApi.Application.Features.Products.Queries.GetProductById;
using ProductApi.Application.Services.RedisCacheServices;
using System.Text.Json;

namespace ProductApi.Application.Services.ProductServices
{
    public class ProductService : IProductService
    {
        // Command Handlers
        private readonly ICreateProductCommandHandler _createProductHandler;
        private readonly IUpdateProductCommandHandler _updateProductHandler;
        private readonly IDeleteProductCommandHandler _deleteProductHandler;

        // Query Handlers
        private readonly IGetAllProductsQueryHandler _getAllProductsHandler;
        private readonly IGetProductByIdQueryHandler _getProductByIdHandler;
        private readonly IGetActiveProductsQueryHandler _getActiveProductsHandler;

        // Cache Service
        private readonly ICacheService _cacheService;
        private const string ALL_PRODUCTS_CACHE_KEY = "all_products";
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(1);

        public ProductService(
            ICreateProductCommandHandler createProductHandler,
            IUpdateProductCommandHandler updateProductHandler,
            IDeleteProductCommandHandler deleteProductHandler,
            IGetAllProductsQueryHandler getAllProductsHandler,
            IGetProductByIdQueryHandler getProductByIdHandler,
            IGetActiveProductsQueryHandler getActiveProductsHandler,
            ICacheService cacheService)
        {
            _createProductHandler = createProductHandler;
            _updateProductHandler = updateProductHandler;
            _deleteProductHandler = deleteProductHandler;
            _getAllProductsHandler = getAllProductsHandler;
            _getProductByIdHandler = getProductByIdHandler;
            _getActiveProductsHandler = getActiveProductsHandler;
            _cacheService = cacheService;
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            // Command
            var command = new CreateProductCommand(createProductDto);

            // Handler
            var result = await _createProductHandler.HandleAsync(command);

            await _cacheService.RemoveAsync(ALL_PRODUCTS_CACHE_KEY);

            return result;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            // Command 
            var command = new DeleteProductCommand(productId);

            // Handler
            var result = await _deleteProductHandler.HandleAsync(command);

            if (result)
            {
                await _cacheService.RemoveAsync(ALL_PRODUCTS_CACHE_KEY);
            }

            return result;
        }

        public async Task<List<ActiveProductDto>> GetActiveProductsAsync()
        {
            // Handler
            var result = await _getActiveProductsHandler.HandleAsync();

            return result;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var cachedData = await _cacheService.GetAsync(ALL_PRODUCTS_CACHE_KEY);

            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonSerializer.Deserialize<List<ProductDto>>(cachedData) ?? new List<ProductDto>();
            }

            var result = await _getAllProductsHandler.HandleAsync();

            var serializedData = JsonSerializer.Serialize(result);
            await _cacheService.SetAsync(ALL_PRODUCTS_CACHE_KEY, serializedData, _cacheExpiration);

            return result;
        }

        public async Task<ProductDto?> GetProductByIdAsync(int productId)
        {
            // Query
            var query = new GetProductByIdQuery(productId);

            // Handler
            var result = await _getProductByIdHandler.HandleAsync(query);

            return result;
        }

        public async Task<ProductDto> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            // Command
            var command = new UpdateProductCommand(updateProductDto);

            // Handler
            var result = await _updateProductHandler.HandleAsync(command);

            await _cacheService.RemoveAsync(ALL_PRODUCTS_CACHE_KEY);

            return result;
        }
    }
}
