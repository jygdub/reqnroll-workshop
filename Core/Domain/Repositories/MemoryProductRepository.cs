using Core.Domain.Models;

namespace Core.Domain.Repositories;

public class MemoryProductRepository : IProductRepository
{
    private readonly Dictionary<Guid, Product> _products = new();
    public Task<Guid> CreateProductAsync(Product product)
    {
        _products[product.Id] = product;

        return Task.FromResult(product.Id);
    }

    public Task<Product?> GetProductByIdAsync(Guid productId)
    {
        _products.TryGetValue(productId, out var product);
        return Task.FromResult(product);
    }

    public Task CleanUpAsync()
    {
        _products.Clear();
        return Task.CompletedTask;
    }
}