namespace Discount.Grpc.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = default!;
        public required string Description { get; set; }
        public int Amount { get; set; }
    }
}
