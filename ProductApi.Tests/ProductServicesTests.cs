using Moq;
using ProductApi.Entities;
using ProductApi.Repositories;
using ProductApi.Services;

namespace ProductApi.Tests
{
    public class ProductServicesTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsProductsFromRepository()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Name = "Produit 1", Price = 10, Slug = "produit-1", Description = "desc", Stock = 5 },
                new Product { Name = "Produit 2", Price = 20, Slug = "produit-2", Description = "desc", Stock = 3 }
            };

            var repoMock = new Mock<IProductRepository>();
            repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(products);

            var service = new ProductServices(repoMock.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.Equal(products, result);
        }
    }
}
