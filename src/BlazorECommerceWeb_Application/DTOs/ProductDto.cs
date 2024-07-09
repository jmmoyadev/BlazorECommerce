using BlazorECommerceWeb_Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Application.DTOs;
public class ProductDto
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    public bool ShopFavorites { get; set; }
    public bool CustomerFavorites { get; set; }
    public string? Color { get; set; } = null;
    public string? ImageUrl { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
    public int CategoryId { get; set; }
    public CategoryDto? Category { get; set; }
}
