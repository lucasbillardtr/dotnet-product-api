using Microsoft.EntityFrameworkCore;
using ProductApi.Database;
using ProductApi.Entities;

namespace ProductApi.Repositories;

/// <inheritdoc />
public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;

    /// <summary>
    ///     Constructeur de la classe ProductRepository
    /// </summary>
    /// <param name="context"></param>
    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }
}