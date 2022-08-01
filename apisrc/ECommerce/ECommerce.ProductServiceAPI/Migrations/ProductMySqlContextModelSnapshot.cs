﻿// <auto-generated />
using System;
using ECommerce.ProductServiceAPI.Data.ORM.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.ProductServiceAPI.Migrations
{
    [DbContext(typeof(ProductMySqlContext))]
    partial class ProductMySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ECommerce.ProductServiceAPI.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("product_create_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("VARCHAR(500)")
                        .HasColumnName("product_description");

                    b.Property<byte[]>("Image")
                        .HasColumnType("longblob")
                        .HasColumnName("product_image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("product_name");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("VARCHAR(900)")
                        .HasColumnName("product_other_datails");

                    b.Property<decimal>("Price")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("product_price");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int")
                        .HasColumnName("productType_Id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("product_quantity");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("product_update_date");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ECommerce.ProductServiceAPI.Domain.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ushort>("Category")
                        .HasColumnType("smallint unsigned")
                        .HasColumnName("product_type_category");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("product_type_create_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("product_type_name");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("product_type_update_date");

                    b.HasKey("Id");

                    b.ToTable("ProductType", (string)null);
                });

            modelBuilder.Entity("ECommerce.ProductServiceAPI.Domain.Entities.Product", b =>
                {
                    b.HasOne("ECommerce.ProductServiceAPI.Domain.Entities.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("ECommerce.ProductServiceAPI.Domain.Entities.ProductType", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
