using ECommerce.CouponServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.CouponServiceAPI.Data.ORM.Mappings
{
    public class CouponMapping : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.ToTable(nameof(Coupon));
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.CouponCode).IsUnique();
            builder.Property(c => c.CouponCode).HasColumnType("char(20)")
                .HasColumnName("coupon_code").IsRequired();

            builder.Property(c => c.DiscountAmount).HasColumnType("decimal(12, 2)")
                .HasColumnName("discount_amount").IsRequired();

            builder.Property(c => c.CreateDate).HasColumnType("datetime2")
                .HasColumnName("create_date").IsRequired();

            builder.Property(c => c.UpdateDate).HasColumnType("datetime2")
               .HasColumnName("update_date").IsRequired();

            builder.HasData(
                    new Coupon
                    {
                        Id = 1,
                        CouponCode = "Coupon_disc_10",
                        DiscountAmount = 10,
                        CreateDate = DateTime.Now
                    },
                    new Coupon
                    {
                        Id = 2,
                        CouponCode = "Coupon_disc_15",
                        DiscountAmount = 15,
                        CreateDate = DateTime.Now
                    },
                    new Coupon
                    {
                        Id = 3,
                        CouponCode = "Coupon_disc_20",
                        DiscountAmount = 20,
                        CreateDate = DateTime.Now
                    },
                    new Coupon
                    {
                        Id = 4,
                        CouponCode = "Coupon_disc_30",
                        DiscountAmount = 30,
                        CreateDate = DateTime.Now
                    },
                    new Coupon
                    {
                        Id = 5,
                        CouponCode = "Coupon_disc_50",
                        DiscountAmount = 50,
                        CreateDate = DateTime.Now
                    }
                );
        }
    }
}
