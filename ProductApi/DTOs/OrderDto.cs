using ProductApi.Entities;

namespace ProductApi.DTOs;

/// <summary>
/// DTO pour afficher les détails d'une commande.
/// </summary>
public class OrderDto
{
    public int Id { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = new();
    public decimal TotalAmount { get; set; }
    public DateTime? UpdatedAt { get; set; }
}