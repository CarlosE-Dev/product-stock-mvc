﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using product_stock_mvc.DataAcess.Context;

#nullable disable

namespace product_stock_mvc.DataAcess.Migrations
{
    [DbContext(typeof(ProductStockDbContext))]
    [Migration("20221217030257_Provider_Document_Field_Update")]
    partial class Provider_Document_Field_Update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("product_stock_mvc.Business.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("QuantityInStock")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("PS_PRODUCTS", (string)null);
                });

            modelBuilder.Entity("product_stock_mvc.Business.Models.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<int>("ProviderType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PS_PROVIDERS", (string)null);
                });

            modelBuilder.Entity("product_stock_mvc.Business.Models.Product", b =>
                {
                    b.HasOne("product_stock_mvc.Business.Models.Provider", "Provider")
                        .WithMany("Products")
                        .HasForeignKey("ProviderId")
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("product_stock_mvc.Business.Models.Provider", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
