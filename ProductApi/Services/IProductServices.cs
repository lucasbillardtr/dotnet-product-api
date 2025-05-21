namespace ProductApi.Services;

using ProductApi.Entities;

public interface IProductServices
{
    Task<List<Product>> GetAllAsync();
}
