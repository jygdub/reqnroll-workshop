using Core.Domain.Models;
using Core.Domain.Repositories;
using Core.Utility;

namespace B.AdditionalScenarios.Tests.Steps;

[Binding]
public class ProductSteps(ScenarioContext scenarioContext, IProductRepository productRepository)
{
    [Given(@"Product '(.*)' of type '(.*)' with a price of '(.*)' exists")]
    public async Task GivenProductWithAPriceOfExists(string name, ProductType type, string priceString)
    {
        var price = priceString.ParseEuroAmount();
        
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