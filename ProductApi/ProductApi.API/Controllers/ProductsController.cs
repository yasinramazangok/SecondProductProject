using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Application.Features.Products.DTOs;
using ProductApi.Application.Services.ProductServices;

namespace ProductApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetActiveProducts()
        {
            var activeProducts = await _productService.GetActiveProductsAsync();
            return Ok(activeProducts);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdProduct = await _productService.CreateProductAsync(createProductDto);
            return CreatedAtAction(nameof(GetProductById),
                new { id = createdProduct.ProductId }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (id != updateProductDto.ProductId)
                return BadRequest("ID'ler eşleşmiyor!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedProduct = await _productService.UpdateProductAsync(updateProductDto);
                return Ok(updatedProduct);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
