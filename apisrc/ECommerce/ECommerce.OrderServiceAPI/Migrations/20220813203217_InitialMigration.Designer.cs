﻿// <auto-generated />
using System;
using ECommerce.OrderServiceAPI.Data.ORM.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.OrderServiceAPI.Migrations
{
    [DbContext(typeof(OrderSqlServerContext))]
    [Migration("20220813203217_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ECommerce.OrderServiceAPI.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("count");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<int>("OrderHeaderId")
                        .HasColumnType("int")
                        .HasColumnName("order_header_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("price");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("product_name");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.HasIndex("OrderHeaderId");

                    b.ToTable("OrderDetailMapping", (string)null);
                });

            modelBuilder.Entity("ECommerce.OrderServiceAPI.Domain.Entities.OrderHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CartTotalItens")
                        .HasColumnType("int")
                        .HasColumnName("total_itens");

                    b.Property<string>("CouponCode")
                        .IsUnicode(true)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("coupon_code");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("discount_amount");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("bit")
                        .HasColumnName("payment_status");

                    b.Property<decimal>("PurchaseAmount")
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("purchase_amount");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OrderHeader", (string)null);
                });

            modelBuilder.Entity("ECommerce.OrderServiceAPI.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("ECommerce.OrderServiceAPI.Domain.Entities.OrderHeader", "OrderHeader")
                        .WithMany("OrderDetail")
                        .HasForeignKey("OrderHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderHeader");
                });

            modelBuilder.Entity("ECommerce.OrderServiceAPI.Domain.Entities.OrderHeader", b =>
                {
                    b.OwnsOne("ECommerce.OrderServiceAPI.Domain.ValueObjects.CardPaymentVO", "CardPayment", b1 =>
                        {
                            b1.Property<int>("OrderHeaderId")
                                .HasColumnType("int");

                            b1.Property<string>("CVV")
                                .IsRequired()
                                .HasColumnType("char(3)")
                                .HasColumnName("cvv");

                            b1.Property<string>("CardNumber")
                                .IsRequired()
                                .HasColumnType("char(16)")
                                .HasColumnName("card_number");

                            b1.Property<string>("ExpiryMonthYear")
                                .IsRequired()
                                .HasColumnType("char(10)")
                                .HasColumnName("expiry_month_year");

                            b1.HasKey("OrderHeaderId");

                            b1.ToTable("OrderHeader");

                            b1.WithOwner()
                                .HasForeignKey("OrderHeaderId");
                        });

                    b.OwnsOne("ECommerce.OrderServiceAPI.Domain.ValueObjects.CustomerVO", "Customer", b1 =>
                        {
                            b1.Property<int>("OrderHeaderId")
                                .HasColumnType("int");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .IsUnicode(true)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("e_mail");

                            b1.Property<string>("FisrtName")
                                .IsRequired()
                                .IsUnicode(true)
                                .HasColumnType("varchar(50)")
                                .HasColumnName("first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .IsUnicode(true)
                                .HasColumnType("varchar(50)")
                                .HasColumnName("last_name");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .IsUnicode(true)
                                .HasColumnType("varchar(14)")
                                .HasColumnName("phone");

                            b1.Property<string>("UserId")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("user_id");

                            b1.HasKey("OrderHeaderId");

                            b1.ToTable("OrderHeader");

                            b1.WithOwner()
                                .HasForeignKey("OrderHeaderId");
                        });

                    b.Navigation("CardPayment")
                        .IsRequired();

                    b.Navigation("Customer")
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerce.OrderServiceAPI.Domain.Entities.OrderHeader", b =>
                {
                    b.Navigation("OrderDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
