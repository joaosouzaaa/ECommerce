using ECommerce.OrderServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.OrderServiceAPI.Data.ORM.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(ProductMapping));
        builder.HasKey(o => o.Id);

        builder.Property(o => o.OrderHeaderId).HasColumnName("order_header_id");
        builder.Property(o => o.ProductId).HasColumnName("product_id");

        builder.Property(o => o.ProductName).HasColumnType("varchar(50)").IsUnicode()
            .HasColumnName("product_name").IsRequired();

        builder.Property(o => o.Price).HasColumnType("decimal(12, 2)")
            .HasColumnName("price").IsRequired();

        builder.Property(o => o.Amount).HasColumnName("count").IsRequired();

        builder.Property(o => o.CreateDate).HasColumnType("datetime2")
            .HasColumnName("create_date").IsRequired();

        builder.Property(o => o.UpdateDate).HasColumnType("datetime2")
            .HasColumnName("update_date").IsRequired(false);
    }
}
