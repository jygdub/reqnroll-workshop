using Core.Domain.Models;
using Core.Domain.Repositories;
using Core.Utility;

namespace C.Hooks.Tests.Steps;

[Binding]
public class ProductSteps(ScenarioContext scenarioContext, IProductRepository productRepository)
{
    [Given(@"the following products exists:")]
    public async Task GivenTheFollowingProductsExists(Table table)
    {
        foreach (var row in table.Rows)
        {
            var type = Enum.Parse<ProductType>(row["Type"], true);
            var priceString = row["Price"];
            var name = row["Name"];
            
            await GivenProductWithAPriceOfExists(name, type, priceString);
        }
    }
    
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