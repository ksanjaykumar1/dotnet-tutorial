﻿// <auto-generated />
using Mango.Services.CouponAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mango.Services.CouponAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250305073248_AddCouponToDb")]
    partial class AddCouponToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Mango.Services.CouponAPI.Models.Coupon", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("double");

                    b.Property<int>("MinAmount")
                        .HasColumnType("int");

                    b.HasKey("CouponId");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            CouponId = 1,
                            CouponCode = "WELCOME10",
                            DiscountAmount = 10.0,
                            MinAmount = 100
                        },
                        new
                        {
                            CouponId = 2,
                            CouponCode = "SUMMER20",
                            DiscountAmount = 20.0,
                            MinAmount = 200
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
