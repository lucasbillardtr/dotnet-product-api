namespace ProductApi.DTOs;

/// <summary>
/// DTO pour le rapport de stock
/// </summary>
public class StockReportDto
{
    /// <summary>
    /// Nombre total de produits en stock (somme des stocks de tous les produits)
    /// </summary>
    public int TotalStockQuantity { get; set; }

    /// <summary>
    /// Valeur totale du stock (somme de (prix * stock) pour tous les produits)
    /// </summary>
    public decimal TotalStockValue { get; set; }
}