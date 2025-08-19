using ProductApi.Application.Features.Products.DTOs;

namespace ProductApi.Application.Features.Products.Commands.UpdateProduct
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
