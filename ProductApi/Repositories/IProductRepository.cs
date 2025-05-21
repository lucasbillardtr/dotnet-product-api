using ProductApi.Entities;

namespace ProductApi.Repositories;

/// <summary>
///     Interface de repository pour les produits
/// </summary>
public interface IProductRepository
{
    /// <summary>
    ///     Récupère tous les produits de la base de données
    /// </summary>
    /// <returns>
    ///     Une liste de produits
    /// </returns>
    Task<List<Product>> GetAllAsync();
}