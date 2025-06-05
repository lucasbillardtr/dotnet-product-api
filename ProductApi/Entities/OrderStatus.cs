namespace ProductApi.Entities;

/// <summary>
/// Statuts possibles pour une commande
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// Commande confirmée par le client, en attente de préparation.
    /// </summary>
    Confirmed,

    /// <summary>
    /// Commande préparée et envoyée au client.
    /// </summary>
    Sent,

    /// <summary>
    /// Commande livrée au client.
    /// </summary>
    Delivered,

    /// <summary>
    /// Commande retournée par le client.
    /// </summary>
    Returned,

    /// <summary>
    /// Commande annulée.
    /// </summary>
    Cancelled
}