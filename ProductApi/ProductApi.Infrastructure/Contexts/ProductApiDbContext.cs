using Microsoft.EntityFrameworkCore;
using ProductApi.Application.Interfaces;
using ProductApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Infrastructure.Contexts
{
    public class ProductApiDbContext : DbContext, IProductApiDbContext
    {
        public ProductApiDbContext(DbContextOptions<ProductApiDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
