﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
}
