using ECommerce.ProductServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.ProductServiceAPI.Data.ORM.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));
        builder.HasKey(p => p.Id);
        builder.Property(p => p.ProductTypeId).HasColumnName("productType_Id");

        builder.Property(p => p.Image).HasColumnType("longblob")
            .HasColumnName("product_image").IsRequired(false);

        builder.Property(p => p.Name).HasColumnType("varchar(50)").IsUnicode()
            .HasColumnName("product_name").IsRequired();

        builder.Property(p => p.Description).HasColumnType("varchar(500)").IsUnicode()
            .HasColumnName("product_description").IsRequired();

        builder.Property(p => p.OtherDetails).HasColumnType("varchar(900)").IsUnicode()
            .HasColumnName("product_other_datails").IsRequired();

        builder.Property(p => p.Amount).HasColumnType("int")
            .HasColumnName("product_quantity").IsRequired();

        builder.Property(p => p.Price).HasColumnType("decimal").HasPrecision(12, 2)
            .HasColumnName("product_price").IsRequired();

        builder.Property(p => p.CreateDate).HasColumnType("datetime")
            .HasColumnName("product_create_date").IsRequired(); 
        
        builder.Property(p => p.UpdateDate).HasColumnType("datetime")
            .HasColumnName("product_update_date").IsRequired();

    }
}
