using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Application.DTOs;
public class CategoryDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter name")]
    [MaxLength(25)]
    public string Name { get; set; } = null!;
}
