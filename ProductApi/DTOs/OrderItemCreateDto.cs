using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs;

/// <summary>
/// DTO pour la création d'une ligne de commande.
/// </summary>
public class OrderItemCreateDto
{
    /// <summary>
    /// ID du produit.
    /// </summary>
    [Required]
    public int ProductId { get; set; }

    /// <summary>
    /// Quantité du produit.
    /// </summary>
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
    public int Quantity { get; set; }
}