namespace ProductApi.DTOs;

/// <summary>
/// DTO pour la mise à jour d'un produit
/// </summary>
public class ProductUpdateDto
{
    /// <summary>
    /// Nom du produit
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Prix du produit
    /// </summary>
    public required decimal Price { get; init; }

    /// <summary>
    /// Stock disponible
    /// </summary>
    public required int Stock { get; init; }

    /// <summary>
    /// Description du produit
    /// </summary>
    public string? Description { get; init; }
}