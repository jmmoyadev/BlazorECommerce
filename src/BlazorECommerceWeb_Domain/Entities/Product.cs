using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Domain.Entities;
public class Product: EntityBase<Product>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool ShopFavorites { get; set; }
    public bool CustomerFavorites { get; set; }
    public string Color { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
