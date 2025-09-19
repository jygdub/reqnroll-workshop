using Core.Domain.Models;
using Core.Domain.Repositories;

namespace E.Final.Tests.Steps;

[Binding]
public class ProductSteps(ScenarioContext scenarioContext, IProductRepository productRepository)
{
    [StepArgumentTransformation]
    public IEnumerable<Product> TransformProducts(Table table)
    {
        return table.CreateSet<Product>();
    }

    [Given(@"the following products exists:")]
    public async Task GivenTheFollowingProductsExists(IEnumerable<Product> products)
    {
        foreach (var product in products)
        {
            var id = await productRepository.CreateProductAsync(product);
            scenarioContext.Set(id, product.Name);
        }
    }
    
    [Given(@"Product '(.*)' of type '(.*)' with a price of '(.*)' exists")]
    public async Task GivenProductWithAPriceOfExists(string name, ProductType type, decimal price)
    {
        var productAlreadyExists = scenarioContext.TryGetValue<Guid>(name, out _);
        if (productAlreadyExists)
        {
            throw new InvalidOperationException($"Product '{name}' already exists in the scenario context.");
        }
        
        var product = new Product
        {
            Type = type,
            Name = name,
            Price = price
        };

        var productId = await productRepository.CreateProductAsync(product);
        scenarioContext.Set(productId, name);
    }
}