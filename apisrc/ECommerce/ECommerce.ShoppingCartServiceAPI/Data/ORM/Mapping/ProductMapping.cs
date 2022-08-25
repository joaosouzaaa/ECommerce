using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.ShoppingCartServiceAPI.Data.ORM.Mapping;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));
        builder.HasKey(p => p.Id);

        builder.Property(p => p.ProductTypeId).HasColumnName("ProductType_Id");
        builder.Property(p => p.ShoppingCartHeaderId).HasColumnName("ShoppingCartHeader_Id");

        builder.Property(p => p.Image).HasColumnType("varbinary(max)").IsUnicode()
            .HasColumnName("image").IsRequired();

        builder.Property(p => p.Name).HasColumnType("varchar(50)").IsUnicode()
            .HasColumnName("name").IsRequired();

        builder.Property(p => p.Description).HasColumnType("varchar(150)").IsUnicode()
            .HasColumnName("description").IsRequired();

        builder.Property(p => p.OtherDetails).HasColumnType("varchar(250)").IsUnicode()
            .HasColumnName("other_details").IsRequired();

        builder.Property(p => p.Amount).HasColumnName("quantity").IsRequired();

        builder.Property(p => p.Price).HasColumnType("decimal(12,2)")
            .HasColumnName("price").IsRequired();

        builder.Property(c => c.CreateDate).HasColumnType("datetime2")
            .HasColumnName("create_date").IsRequired();

        builder.Property(c => c.UpdateDate).HasColumnType("datetime2")
            .HasColumnName("Update_date").IsRequired(false);

        builder.HasOne(p => p.ProductType).WithMany(pt => pt.Products)
            .HasForeignKey(p => p.ProductTypeId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
