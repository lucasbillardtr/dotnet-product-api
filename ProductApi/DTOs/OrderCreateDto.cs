using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs;

/// <summary>
/// DTO pour la création d'une commande.
/// </summary>
public class OrderCreateDto
{
    /// <summary>
    /// Liste des produits et leurs quantités pour la commande.
    /// </summary>
    [Required]
    [MinLength(1, ErrorMessage = "Order must contain at least one product.")]
    public List<OrderItemCreateDto> Products { get; set; } = new();
}