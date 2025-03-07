using System;
using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {

    }
    // Coupons will be the table name
    public DbSet<Coupon> Coupons { get; set; }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Coupon>().HasData(
            new Coupon { CouponId = 1, CouponCode = "WELCOME10", DiscountAmount = 10, MinAmount = 100 },
            new Coupon { CouponId = 2, CouponCode = "SUMMER20", DiscountAmount = 20, MinAmount = 200 }
        );
    }


}
