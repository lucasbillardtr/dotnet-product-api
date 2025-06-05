namespace ProductApi.DTOs;

/// <summary>
/// DTO pour la création d'un produit
/// </summary>
public class ProductCreateDto
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