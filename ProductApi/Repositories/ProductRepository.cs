using Microsoft.EntityFrameworkCore;
using ProductApi.Database;
using ProductApi.Entities;
using System.Threading.Tasks;

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

    /// <inheritdoc />
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    /// <inheritdoc />
    public async Task<Product> AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    /// <inheritdoc />
    public async Task<bool> DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        return await _context.SaveChangesAsync() > 0;
    }

    /// <inheritdoc />
    public async Task<List<Product>> SearchAsync(string? name, string? sortBy, int offset, int limit, bool onlyAvailable = false)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(p => EF.Functions.Like(p.Name, $"%{name}%"));
        }

        if (onlyAvailable)
        {
            query = query.Where(p => p.Stock > 0);
        }

        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            // Simple sort by price for now. Can be extended for other fields.
            if (sortBy.Equals("price", StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderBy(p => p.Price);
            }
            // Add more sort options if needed
        }

        return await query
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<int> GetTotalStockQuantityAsync()
    {
        return await _context.Products.SumAsync(p => p.Stock);
    }

    /// <inheritdoc />
    public async Task<decimal> GetTotalStockValueAsync()
    {
        return await _context.Products.SumAsync(p => p.Price * p.Stock);
    }
}