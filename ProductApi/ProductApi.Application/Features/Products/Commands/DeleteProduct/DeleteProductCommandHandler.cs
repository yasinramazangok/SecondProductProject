using ProductApi.Application.Commons.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IDeleteProductCommandHandler
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> HandleAsync(DeleteProductCommand command)
        {
            var product = await _productRepository.GetByIdAsync(command.ProductId);
            if (product == null)
                return false;

            await _productRepository.DeleteAsync(product);

            return true;
        }
    }
}
