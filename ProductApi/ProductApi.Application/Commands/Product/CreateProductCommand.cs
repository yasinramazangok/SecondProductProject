using ProductApi.Application.DTOs.Product;

namespace ProductApi.Application.Commands.Product
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
