using BlazorECommerceWeb_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorECommerceWeb_Infrastructure.Data.Configurations;

public class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPrice>
{
    public void Configure(EntityTypeBuilder<ProductPrice> builder)
    {
        builder.HasOne(p => p.Product)
               .WithMany(p => p.ProductPrices)
               .HasForeignKey(p => p.ProductId);
    }
}
