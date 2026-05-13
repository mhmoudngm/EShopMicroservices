using Discount.Grpc.Data_Access;
using Discount.Grpc.Models;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly ApplicationDbContext dbContext;

        public DiscountService(ApplicationDbContext dbContext, ILogger<DiscountService> logger)
        {
            this.dbContext = dbContext;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            if (request.Coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "invalid Argument"));

            var coupon = new Coupon()
            {
                Description = request.Coupon.Description,
                Amount = request.Coupon.Amount,
                ProductName = request.Coupon.ProductName
            };
            dbContext.Coupons.Add(coupon);
            await dbContext.SaveChangesAsync();
            return request.Coupon;
            // return Task.FromResult(request.Coupon); if it sync
        }
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = dbContext.Coupons.FirstOrDefault(i => i.ProductName == request.ProductName);
            return new CouponModel()
            {
                Description = coupon.Description,
                Amount = coupon.Amount,
                ProductName = coupon.ProductName,
                Id = coupon.Id
            };
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var record = dbContext.Coupons.FirstOrDefault(i=>i.Id==request.Coupon.Id);
            if (record == null)
                throw new RpcException(new Status(StatusCode.NotFound, "not found coupon"));

            record.Description = request.Coupon.Description;  
            record.Amount = request.Coupon.Amount;
            record.ProductName = request.Coupon.ProductName;

            await dbContext.SaveChangesAsync();
            return request.Coupon;
        }
        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
           var coupon = await dbContext.Coupons.FirstOrDefaultAsync(i=>i.ProductName==request.ProductName);
            if (coupon == null)
                throw new RpcException(new Status(StatusCode.NotFound,"not found coupon"));

            dbContext.Coupons.Remove(coupon);
            await dbContext.SaveChangesAsync();
            return new DeleteDiscountResponse() { Success = true };
        }
    }
}
