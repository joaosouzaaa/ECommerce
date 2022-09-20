using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.ShoppingCartServiceAPI.Data.ORM.Mapping
{
    public class CustomerMapping : BaseMapping, IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", Schema);
            builder.HasKey(c => c.Id);

            builder.Property(c => c.UserId).HasColumnName("User_Id");

            builder.Property(c => c.ShoppingCartHeaderId).HasColumnName("ShoppingCartHeader_Id");

            builder.Property(c => c.FisrtName).HasColumnType("varchar(50)").IsUnicode()
                .HasColumnName("fisrt_name").IsRequired();

            builder.Property(c => c.LastName).HasColumnType("varchar(50)").IsUnicode()
                .HasColumnName("last_name").IsRequired();

            builder.Property(c => c.Phone).HasColumnType("varchar(11)").IsUnicode()
                .HasColumnName("phone").IsRequired();

            builder.Property(c => c.Email).HasColumnType("varchar(150)").IsUnicode()
                .HasColumnName("email").IsRequired();

            builder.Property(c => c.CreateDate).HasColumnType("datetime2")
                .HasColumnName("create_date").IsRequired();

            builder.Property(c => c.UpdateDate).HasColumnType("datetime2")
                .HasColumnName("Update_date").IsRequired(false);
        }
    }
}
