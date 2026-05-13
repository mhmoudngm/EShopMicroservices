using Discount.Grpc.Configurations;
using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Discount.Grpc.Data_Access
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CouponConfiguration).Assembly!);
        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}
