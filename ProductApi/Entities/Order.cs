using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Entities;

/// <summary>
/// Entité représentant une commande
/// </summary>
public class Order
{
    /// <summary>
    /// ID de la commande
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Numéro unique de la commande (ex: "CMD-20240523-XXXXX")
    /// </summary>
    [Required]
    [StringLength(50)]
    public required string OrderNumber { get; set; }

    /// <summary>
    /// Date de création de la commande
    /// </summary>
    [Required]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Statut actuel de la commande
    /// </summary>
    [Required]
    public OrderStatus Status { get; set; }

    /// <summary>
    /// Liste des lignes de produits dans la commande
    /// </summary>
    public List<OrderItem> OrderItems { get; set; } = new();

    /// <summary>
    /// Date de la dernière mise à jour de la commande
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Montant total de la commande
    /// </summary>
    [NotMapped] // Calculé, pas stocké directement en DB si on le recalcule à chaque fois
    public decimal TotalAmount => OrderItems.Sum(item => item.Quantity * item.UnitPrice);
}