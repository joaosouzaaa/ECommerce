using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.ShoppingCartServiceAPI.Data.ORM.Mapping
{
    public class CardPaymentMapping : BaseMapping,  IEntityTypeConfiguration<CardPayment>
    {
        public void Configure(EntityTypeBuilder<CardPayment> builder)
        {
            builder.ToTable("CardPayment", Schema);
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ShoppingCartHeaderId).HasColumnName("ShoppingCartHeader_Id");

            builder.Property(c => c.CardNumber).HasColumnType("char(16)")
                .HasColumnName("card_number").IsRequired();

            builder.Property(c => c.ExpiryMonthYear).HasColumnType("char(10)")
                .HasColumnName("expiry_month_year").IsRequired();

            builder.Property(c => c.CVV).HasColumnType("char(3)")
                .HasColumnName("cvv").IsRequired();

            builder.Property(c => c.CreateDate).HasColumnType("datetime2")
                .HasColumnName("create_date").IsRequired();

            builder.Property(c => c.UpdateDate).HasColumnType("datetime2")
                .HasColumnName("Update_date").IsRequired(false);
        }
    }
}
