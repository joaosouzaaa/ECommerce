using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.ShoppingCartServiceAPI.Data.ORM.Mapping
{
    public class ProductTypeMapping : BaseMapping, IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductType", Schema);
            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.Name).HasColumnType("varchar(50)").IsUnicode()
                .HasColumnName("name").IsRequired();

            builder.Property(pt => pt.Category).HasColumnName("category").IsRequired();

            builder.Property(pt => pt.CreateDate).HasColumnType("datetime2")
                .HasColumnName("create_date").IsRequired();

            builder.Property(pt => pt.UpdateDate).HasColumnType("datetime2")
               .HasColumnName("update_date").IsRequired(false);
        }
    }
}
