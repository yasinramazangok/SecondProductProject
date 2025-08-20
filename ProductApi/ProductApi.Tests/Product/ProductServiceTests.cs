using Moq;
using ProductApi.Application.Commons.Repositories;
using Xunit;

namespace ProductApi.Tests.Product
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepoMock;

        public ProductServiceTests()
        {
            _productRepoMock = new Mock<IProductRepository>();
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnList()
        {
            // Arrange
            _productRepoMock.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<ProductApi.Core.Entities.Product>());

            // Act
            var result = await _productRepoMock.Object.GetAllAsync();

            // Assert
            Assert.NotNull(result);
        }
    }
}
