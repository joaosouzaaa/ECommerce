using ECommerce.ProductServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.ProductServiceAPI.Data.ORM.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));
        builder.HasKey(p => p.Id).HasName("productId");
        builder.Property(p => p.ProductTypeId).HasColumnName("productType_Id");

        builder.Property(p => p.Name).HasColumnType("varchar(50)").IsUnicode()
            .HasColumnName("name").IsRequired();

        builder.Property(p => p.Description).HasColumnType("varchar(250)").IsUnicode()
            .HasColumnName("description").IsRequired();

        builder.Property(p => p.OtherDetails).HasColumnType("varchar(250)").IsUnicode()
            .HasColumnName("other_datails").IsRequired(false);

        builder.Property(p => p.Quantity).HasColumnType("int")
            .HasColumnName("quantity").IsRequired();

        builder.Property(p => p.Price).HasColumnType("decimal").HasPrecision(12, 2)
            .HasColumnName("price").IsRequired();

        builder.Property(p => p.CreateDate).HasColumnType("datetime")
            .HasColumnName("create_date").IsRequired(); 
        
        builder.Property(p => p.UpdateDate).HasColumnType("datetime")
            .HasColumnName("update_date").IsRequired();

    }
}
