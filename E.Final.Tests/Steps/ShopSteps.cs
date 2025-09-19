using Core.Domain.Models;
using Core.Drivers;
using FluentAssertions;

namespace E.Final.Tests.Steps;

[Binding]
public class ShopSteps(ScenarioContext scenarioContext, ShopDriver shopDriver)
{
    [Given(@"the customer has a shopping cart with no products")]
    public async Task GivenCustomerHasAShoppingCartWithNoProducts()
    {
        await shopDriver.ClearShoppingCartAsync();
    }

    [Given(@"the customer adds '(.*)' to their shopping cart")]
    public async Task GivenCustomerAddsToTheirShoppingCart(string productName)
    {
        var productId = scenarioContext.Get<Guid>(productName);
        
        await shopDriver.AddProductToShoppingCartAsync(productId);
    }

    [When(@"the customer checks out their shopping cart")]
    public async Task WhenCustomerChecksOutTheirShoppingCart()
    {
        var order = await shopDriver.CheckoutShoppingCartAsync();
        
        scenarioContext.Set(order, $"Order");
    }

    [Then(@"the total price of the order is '(.*)'")]
    public void ThenTheTotalPriceOfTheShoppingCartIs(decimal totalPrice)
    {
        var order = scenarioContext.Get<Order>("Order");
        order.ProductsCost.Should().Be(totalPrice, "because the total price of the order should match the expected total price.");
    }

    [Then(@"the costs for shipping are '(.*)'")]
    public void ThenTheCostsForShippingAre(decimal shippingCosts)
    {
        var order = scenarioContext.Get<Order>("Order");
        order.ShippingCost.Should().Be(shippingCosts, "because the shipping costs should match the expected value.");
    }
}