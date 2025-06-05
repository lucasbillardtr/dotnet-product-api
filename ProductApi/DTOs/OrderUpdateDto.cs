using ProductApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs;

/// <summary>
/// DTO pour la mise à jour d'une commande (principalement le statut).
/// Les produits d'une commande existante ne sont généralement pas modifiés directement,
/// mais on pourrait l'étendre si nécessaire.
/// </summary>
public class OrderUpdateDto
{
    /// <summary>
    /// Nouveau statut de la commande.
    /// </summary>
    [Required]
    public OrderStatus Status { get; set; }

    // Si la modification des produits d'une commande est permise (plus complexe) :
    // public List<OrderItemUpdateDto>? Products { get; set; }
}

// Si on permet la modification des items (non demandé explicitement par l'exemple de PUT)
// public class OrderItemUpdateDto
// {
//     [Required]
//     public int ProductId { get; set; }
//
//     [Required]
//     [Range(1, int.MaxValue)]
//     public int Quantity { get; set; }
// }