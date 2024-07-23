using BlazorECommerceWeb_Domain.Entities;
using BlazorECommerceWeb_Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Infrastructure.Data.Repositories;

public class ProductPriceRepository : GenericRepository<ProductPrice>, IProductPriceRepository
{
    public ProductPriceRepository(IDbContextFactory<ApplicationDbContext> factory) : base(factory)
    {
    }
}
