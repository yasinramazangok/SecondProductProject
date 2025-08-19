namespace ProductApi.Application.Commands.Product
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
