using ProductApi.Application.Features.Products.DTOs;

namespace ProductApi.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand
    {
        public CreateProductDto _createProductDto { get; set; }
        public CreateProductCommand(CreateProductDto createProductDto)
        {
            _createProductDto = createProductDto;
        }
    }
}
