namespace ProductApi.Services;

using ProductApi.Entities;
using ProductApi.DTOs;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(ProductCreateDto productDto);
    Task<Product?> UpdateAsync(int id, ProductUpdateDto productDto);
    Task<bool> DeleteAsync(int id);

    /// <summary>
    /// Recherche des produits avec filtres, tri et pagination.
    /// </summary>
    /// <param name="name">Nom partiel du produit (insensible à la casse).</param>
    /// <param name="sortBy">Champ de tri (ex: "price").</param>
    /// <param name="offset">Nombre d'éléments à sauter.</param>
    /// <param name="limit">Nombre maximum d'éléments à retourner.</param>
    /// <returns>Une liste de produits.</returns>
    Task<List<Product>> SearchProductsAsync(string? name, string? sortBy, int offset, int limit);

    /// <summary>
    /// Récupère les produits disponibles (stock > 0).
    /// </summary>
    /// <returns>Une liste de produits disponibles.</returns>
    Task<List<Product>> GetAvailableProductsAsync();

    /// <summary>
    /// Génère un rapport sur l'état du stock.
    /// </summary>
    /// <returns>Un DTO contenant le rapport de stock.</returns>
    Task<StockReportDto> GetStockReportAsync();
}
