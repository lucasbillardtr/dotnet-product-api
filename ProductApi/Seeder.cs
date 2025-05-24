using ProductApi.Database;
using ProductApi.Entities;

namespace ProductApi;

/// <summary>
///     Classe de seed pour la base de données
/// </summary>
public static class DatabaseSeeder
{
    /// <summary>
    ///     Méthode de seed pour la base de données
    /// </summary>
    /// <param name="context">
    ///     Le contexte de la base de données
    /// </param>
    public static void Seed(ProductDbContext context)
    {
        if (!context.Products.Any())
        {
            var now = DateOnly.FromDateTime(DateTime.Now);

            context.Products.AddRange(
                new Product
                {
                    Name = "Écharpe rouge", Price = 10.0m, Slug = "echarpe-rouge",
                    Description = "Jolie petite écharpe en soie", CreatedAt = now,
                    Stock = 15
                },
                new Product
                {
                    Name = "Slip kangourou", Price = 20.0m, Slug = "slip-kangourou",
                    Description = "Slip kangourou vert fluo, très viril", CreatedAt = now,
                    Stock = 30
                },
                new Product
                {
                    Name = "Robe en daim", Price = 30.0m, Slug = "robe-en-daim",
                    Description = "Robe en daim très doux",
                    CreatedAt = now,
                    Stock = 8
                }
            );

            context.SaveChanges();
        }
    }
}
