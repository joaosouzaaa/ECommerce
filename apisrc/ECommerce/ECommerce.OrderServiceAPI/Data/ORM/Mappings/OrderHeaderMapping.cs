using ECommerce.OrderServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.OrderServiceAPI.Data.ORM.Mappings
{
    public class OrderHeaderMapping : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.ToTable(nameof(OrderHeader));
            builder.HasKey(o => o.Id);


            builder.Property(o => o.CouponCode).HasColumnType("varchar(25)").IsUnicode()
                .HasColumnName("coupon_code").IsRequired(false);

            builder.Property(o => o.PurchaseAmount).HasColumnType("decimal(12, 2)")
               .HasColumnName("purchase_amount").IsRequired();

            builder.Property(o => o.DiscountAmount).HasColumnType("decimal(12, 2)")
               .HasColumnName("discount_amount").IsRequired();

            builder.Property(o => o.CartTotalItens).HasColumnName("total_itens").IsRequired();

            builder.Property(o => o.PaymentStatus).HasColumnType("bit").HasColumnName("payment_status").IsRequired();

            builder.OwnsOne(o => o.Customer, config =>
            {
                config.Property(c => c.UserId).HasColumnName("user_id");

                config.Property(c => c.FisrtName).HasColumnType("varchar(50)").IsUnicode().HasColumnName("first_name").IsRequired();

                config.Property(c => c.LastName).HasColumnType("varchar(50)").IsUnicode().HasColumnName("last_name").IsRequired();

                config.Property(c => c.Phone).HasColumnType("varchar(14)").IsUnicode().HasColumnName("phone").IsRequired();

                config.Property(c => c.Email).HasColumnType("varchar(100)").IsUnicode().HasColumnName("e_mail").IsRequired();
            });

            builder.OwnsOne(o => o.CardPayment, config =>
            {
                config.Property(cp => cp.CardNumber).HasColumnType("char(16)").HasColumnName("card_number").IsRequired();
                    
                config.Property(cp => cp.ExpiryMonthYear).HasColumnType("char(10)") .HasColumnName("expiry_month_year").IsRequired();
                   
                config.Property(cp => cp.CVV).HasColumnType("char(3)").HasColumnName("cvv").IsRequired();   
            });

            builder.HasMany(oh => oh.OrderDetails)
                   .WithOne(od => od.OrderHeader)
                   .HasForeignKey(od => od.OrderHeaderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
