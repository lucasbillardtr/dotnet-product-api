using ProductApi.Entities;
using ProductApi.Repositories;

namespace ProductApi.Services;

public class ProductServices : IProductServices
{
    private readonly IProductRepository _repository;

    public ProductServices(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}
