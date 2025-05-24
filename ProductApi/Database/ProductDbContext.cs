using Microsoft.EntityFrameworkCore;
using ProductApi.Entities;

namespace ProductApi.Database;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
}