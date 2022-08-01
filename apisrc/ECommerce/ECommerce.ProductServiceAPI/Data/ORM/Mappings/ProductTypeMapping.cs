using ECommerce.ProductServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.ProductServiceAPI.Data.ORM.Mappings;

public class ProductTypeMapping : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.ToTable(nameof(ProductType));
        builder.HasKey(pt => pt.Id);

        builder.Property(pt => pt.Name).HasColumnType("VARCHAR(50)").IsUnicode()
            .HasColumnName("product_type_name").IsRequired();

        builder.Property(pt => pt.Category).HasColumnName("product_type_category").IsRequired();

        builder.Property(pt => pt.CreateDate).HasColumnType("datetime")
        .HasColumnName("product_type_create_date").IsRequired();

        builder.Property(pt => pt.UpdateDate).HasColumnType("datetime")
            .HasColumnName("product_type_update_date").IsRequired();

        builder.HasMany(pt => pt.Products)
            .WithOne(p => p.ProductType)
            .HasForeignKey(p => p.ProductTypeId);
    }
}
