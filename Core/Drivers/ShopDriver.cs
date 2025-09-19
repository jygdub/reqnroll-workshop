using Core.Domain.Models;
using Core.Domain.Repositories;

namespace Core.Drivers;

public class ShopDriver(IProductRepository productRepository)
{
    private readonly List<Product> _shoppingCart = [];

    public Task ClearShoppingCartAsync()
    {
        _shoppingCart.Clear();
        
        return Task.CompletedTask;
    }
    
    public async Task AddProductToShoppingCartAsync(Guid productId)
    {
        var product = await productRepository.GetProductByIdAsync(productId);
        if (product is null)
        {
            throw new ArgumentException($"Product with ID '{productId}' does not exist.");
        }
        
        _shoppingCart.Add(product);
    }

    public Task<Order> CheckoutShoppingCartAsync()
    {
        var productsCost = _shoppingCart.Sum(p => p.Price);
        var shippingCost = CalculateShippingCost();

        var order = new Order(productsCost, shippingCost);

        // Clear the shopping cart after checkout
        _shoppingCart.Clear();

        return Task.FromResult(order);
        
        decimal CalculateShippingCost()
        {
            if(productsCost > 20)
            {
                return 0;
            }
            
            return 3.95m;
        }
    }
}