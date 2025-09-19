using Core.Domain.Models;

namespace Core.Domain.Repositories;

public interface IProductRepository : IRepository
{
    Task<Guid> CreateProductAsync(Product product);
    Task<Product?> GetProductByIdAsync(Guid productId);
}