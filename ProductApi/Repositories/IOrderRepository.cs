using ProductApi.Entities;

namespace ProductApi.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(int id);
    Task<List<Order>> GetAllAsync();
    Task<Order> AddAsync(Order order);
    Task<Order?> UpdateAsync(Order order); // EF Core tracks changes, so SaveChangesAsync is key
    Task<bool> DeleteAsync(int id);
    Task<List<Order>> GetOrdersByStatusAsync(OrderStatus status);
    Task<List<Order>> GetDeliveredOrdersInPeriodAsync(DateTime from, DateTime to);
}