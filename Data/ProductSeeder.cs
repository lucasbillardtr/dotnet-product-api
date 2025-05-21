public static class ProductSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                // ...existing code...
                Stock = 100
            },
            new Product
            {
                // ...existing code...
                Stock = 50
            }
            // ...autres produits si besoin...
        );
    }
}
