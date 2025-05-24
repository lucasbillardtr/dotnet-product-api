namespace ProductApi.Services;

using ProductApi.Entities;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
}
