using Microsoft.EntityFrameworkCore;
using ProductApi.Core.Entities;
using ProductApi.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ProductApiDbContext _context;

        public ProductRepository(ProductApiDbContext context) : base(context)
        {
            _context = context;
        }

        // Example of a product-specific method
        public async Task<IEnumerable<Product>> GetActiveProductsAsync()
        {
            return await _context.Products
                                 .Where(p => p.IsActive)
                                 .ToListAsync();
        }
    }
}
