namespace Core.Domain.Models;

public class Product
{
    public Guid Id { get; set;} = Guid.NewGuid();
    public required ProductType Type { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}