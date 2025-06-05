using ProductApi.DTOs;
using ProductApi.Entities;

namespace ProductApi.Services;

public interface IOrderService
{
    Task<OrderDto?> GetOrderByIdAsync(int id);
    Task<List<OrderDto>> GetAllOrdersAsync();
    Task<(OrderDto? Order, string? ErrorMessage)> CreateOrderAsync(OrderCreateDto orderCreateDto);
    Task<(OrderDto? Order, string? ErrorMessage)> UpdateOrderStatusAsync(int id, OrderStatus newStatus);
    Task<(bool Success, string? ErrorMessage)> DeleteOrderAsync(int id); // Annulation
    Task<List<OrderDto>> GetOrdersByStatusAsync(OrderStatus status);
    Task<List<OrderDto>> GetDeliveredOrdersReportAsync(DateTime from, DateTime to);
}