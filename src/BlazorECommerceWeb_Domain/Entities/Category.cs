using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Domain.Entities;

public class Category: EntityBase<Category>
{
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();

}
