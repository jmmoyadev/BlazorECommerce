namespace BlazorECommerceWeb_Domain.Entities;

public class ProductPrice : EntityBase<ProductPrice>
{
    public int ProductId { get; set; }

    public Product? Product { get; set; }

    public string? Size { get; set; }

    public double Price { get; set; }
}
