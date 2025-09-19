namespace Core.Domain.Models;

public class Order(decimal productsCost, decimal shippingCost)
{
    public decimal ProductsCost { get; } = productsCost;
    public decimal ShippingCost { get; } = shippingCost;
    public decimal OrderTotal => ProductsCost + ShippingCost;
}