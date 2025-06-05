using Microsoft.EntityFrameworkCore;
using ProductApi.Database;
using ProductApi.Entities;

namespace ProductApi.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ProductDbContext _context;

    public OrderRepository(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .ToListAsync();
    }

    public async Task<Order> AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order?> UpdateAsync(Order order)
    {
        // EF Core tracks the entity, so calling SaveChangesAsync will persist updates.
        // The entity should be retrieved, modified, and then SaveChangesAsync called.
        // This method assumes the order entity passed is already being tracked or
        // it's an updated version of an entity that will be marked as modified.
        _context.Entry(order).State = EntityState.Modified; // Ensure it's tracked as modified
        try
        {
            await _context.SaveChangesAsync();
            return order;
        }
        catch (DbUpdateConcurrencyException)
        {
            // Handle concurrency issues if necessary
            return null;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
        {
            return false;
        }

        _context.Orders.Remove(order);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<Order>> GetOrdersByStatusAsync(OrderStatus status)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Where(o => o.Status == status)
            .ToListAsync();
    }

    public async Task<List<Order>> GetDeliveredOrdersInPeriodAsync(DateTime from, DateTime to)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Where(o => o.Status == OrderStatus.Delivered && o.CreatedAt >= from && o.CreatedAt <= to)
            .ToListAsync();
    }
}