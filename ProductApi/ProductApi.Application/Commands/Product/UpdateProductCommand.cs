using ProductApi.Application.DTOs.Product;

namespace ProductApi.Application.Commands.Product
{
    public class UpdateProductCommand
    {
        public UpdateProductDto _updateProductDto { get; set; }
        public UpdateProductCommand(UpdateProductDto updateProductDto)
        {
            _updateProductDto = updateProductDto;
        }
    }
}
