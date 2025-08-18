using ProductApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        // Example of a product-specific method
        Task<IEnumerable<Product>> GetActiveProductsAsync();
    }
}
