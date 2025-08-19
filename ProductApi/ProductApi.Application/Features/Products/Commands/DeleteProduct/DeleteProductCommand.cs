namespace ProductApi.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand
    {
        public int ProductId { get; set; }

        public DeleteProductCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
