using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Entities;

/// <summary>
/// Entité représentant une ligne de produit dans une commande
/// </summary>
public class OrderItem
{
    /// <summary>
    /// ID de la ligne de commande
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// ID de la commande à laquelle cette ligne appartient
    /// </summary>
    [Required]
    public int OrderId { get; set; }

    /// <summary>
    /// Commande parente
    /// </summary>
    [ForeignKey("OrderId")]
    public Order? Order { get; set; }

    /// <summary>
    /// ID du produit commandé
    /// </summary>
    [Required]
    public int ProductId { get; set; }

    /// <summary>
    /// Produit commandé
    /// </summary>
    [ForeignKey("ProductId")]
    public Product? Product { get; set; }

    /// <summary>
    /// Quantité commandée du produit
    /// </summary>
    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    /// <summary>
    /// Prix unitaire du produit au moment de la commande
    /// </summary>
    [Required]
    [Range(0, double.MaxValue)]
    public decimal UnitPrice { get; set; }
}