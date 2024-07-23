using BlazorECommerceWeb_Domain;
using BlazorECommerceWeb_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlazorECommerceWeb_Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; }

    public DbSet<Product> Products { get; }

    public DbSet<ProductPrice> ProductPrices { get; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
