using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Discount.Grpc.Configurations
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasIndex(i => i.ProductName);

            builder.HasData(
               new Coupon() { Id = 10, Description = "iphone x", Amount = 150, ProductName = "iphone x" },
               new Coupon() { Id = 11, Description = "samsung a55", Amount = 150, ProductName = "samsung a55" });
        }
    }
}
