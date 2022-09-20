using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.ShoppingCartServiceAPI.Data.ORM.Mapping
{
    public class ShoppingCartHeaderMapping : BaseMapping, IEntityTypeConfiguration<ShoppingCartHeader>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartHeader> builder)
        {
            builder.ToTable("ShoppingCartHeader", Schema);
            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.CouponCode).HasColumnType("varchar(11)").IsUnicode()
                .HasColumnName("coupon_code").IsRequired(false);

            builder.Property(sc => sc.PurchaseAmount).HasColumnType("decimal(12, 2)")
                .HasColumnName("purchase_amount").IsRequired();

            builder.Property(sc => sc.DiscountAmount).HasColumnType("decimal(12, 2)")
                .HasColumnName("discount_amount").IsRequired();

            builder.Property(sc => sc.CartTotalItens).HasColumnType("int")
                .HasColumnName("cart_total_itens").IsRequired();

            builder.HasOne(sc => sc.Customer).WithOne()
                .HasForeignKey<Customer>(c => c.ShoppingCartHeaderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sc => sc.CardPayment).WithOne()
                .HasForeignKey<CardPayment>(cp => cp.ShoppingCartHeaderId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(sc => sc.Products).WithMany(p => p.shoppingCarts)
                .UsingEntity<Dictionary<string, object>>("ShopingCartProduct", config => 
                {
                    config.HasOne<ShoppingCartHeader>().WithMany().HasForeignKey("ShoppingCartHeader_Id");
                    config.HasOne<Product>().WithMany().HasForeignKey("Product_Id");
                });
        }
    }
}
