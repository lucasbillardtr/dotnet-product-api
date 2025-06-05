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

    /// <summary>
    /// Récupère un produit par son ID
    /// </summary>
    /// <param name="id">L'ID du produit</param>
    /// <returns>Le produit ou null s'il n'existe pas</returns>
    Task<Product?> GetByIdAsync(int id);

    /// <summary>
    /// Ajoute un nouveau produit à la base de données
    /// </summary>
    /// <param name="product">Le produit à ajouter</param>
    /// <returns>Le produit ajouté</returns>
    Task<Product> AddAsync(Product product);

    /// <summary>
    /// Supprime un produit de la base de données
    /// </summary>
    /// <param name="product">Le produit à supprimer</param>
    /// <returns>True si la suppression a réussi, false sinon</returns>
    Task<bool> DeleteAsync(Product product);

    /// <summary>
    /// Recherche des produits en fonction de critères, avec tri et pagination.
    /// </summary>
    /// <param name="name">Nom partiel du produit (insensible à la casse).</param>
    /// <param name="sortBy">Champ de tri (ex: "price").</param>
    /// <param name="offset">Nombre d'éléments à sauter (pagination).</param>
    /// <param name="limit">Nombre maximum d'éléments à retourner (pagination).</param>
    /// <param name="onlyAvailable">Si true, ne retourne que les produits avec stock > 0.</param>
    /// <returns>Une liste de produits correspondants aux critères.</returns>    
    Task<List<Product>> SearchAsync(string? name, string? sortBy, int offset, int limit, bool onlyAvailable = false);

    /// <summary>
    /// Calcule la quantité totale de stock pour tous les produits.
    /// </summary>
    /// <returns>La quantité totale de stock.</returns>
    Task<int> GetTotalStockQuantityAsync();

    /// <summary>
    /// Calcule la valeur totale du stock (somme de prix * stock).
    /// </summary>
    /// <returns>La valeur totale du stock.</returns>
    Task<decimal> GetTotalStockValueAsync();
}