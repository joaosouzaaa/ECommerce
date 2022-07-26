using ECommerce.ProductServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.ProductServiceAPI.Data.ORM.Mappings;

public class ProductTypeMapping : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.ToTable(nameof(ProductType));
        builder.HasKey(pt => pt.Id).HasName("productTypeId");

        builder.Property(pt => pt.Name).HasColumnType("varchar(50)").IsUnicode()
            .HasColumnName("name").IsRequired();

        builder.Property(pt => pt.Category).HasColumnName("category").IsRequired();

        builder.Property(pt => pt.CreateDate).HasColumnType("datetime")
        .HasColumnName("create_date").IsRequired();

        builder.Property(pt => pt.UpdateDate).HasColumnType("datetime")
            .HasColumnName("update_date").IsRequired();

        builder.HasMany(pt => pt.Products)
            .WithOne(p => p.ProductType)
            .HasForeignKey(p => p.ProductTypeId);
    }
}
