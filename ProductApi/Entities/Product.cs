using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Entities;

/// <summary>
///     Entité de produit
/// </summary>
public class Product
{
    /// <summary>
    ///     Id de l'entité, généré automatiquement par la base de données
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    /// <summary>
    ///     Nom du produit
    /// </summary>
    /// <example>Produit 1</example>
    [StringLength(100)]
    public required string Name { get; init; }

    /// <summary>
    ///     Prix du produit ne peut pas être négatif
    /// </summary>
    [Range(0, double.MaxValue)]
    public required decimal Price { get; init; }

    /// <summary>
    ///     Stock disponible pour le produit
    /// </summary>
    [Range(0, int.MaxValue)]
    public required int Stock { get; init; }

    /// <summary>
    ///     Slug du produit, utilisé pour l'URL
    /// </summary>
    /// <example>produit-1</example>
    [StringLength(100)]
    public required string Slug { get; init; }

    /// <summary>
    ///     Description du produit
    /// </summary>
    /// <example>Ceci est une description</example>
    [StringLength(255)]
    public string? Description { get; init; }

    /// <summary>
    ///     Date de création du produit en base
    /// </summary>
    public DateOnly CreatedAt { get; init; }

    /// <summary>
    ///     Date de maj du produit en base
    /// </summary>
    public DateOnly? UpdatedAt { get; init; }
}
