using ProductApi.Application.Features.Products.DTOs;

namespace ProductApi.Application.Features.Products.Queries.GetActiveProducts
{
    public interface IGetActiveProductsQueryHandler
    {
        Task<List<ActiveProductDto>> HandleAsync();
    }
}
