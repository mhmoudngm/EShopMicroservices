namespace Basket.API.Models
{
    public class ShoppingCard
    {
        public string UserName { get; set; } = default!;
        public List<ShoppingCardItem> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

        public ShoppingCard(string userName)
        {
            this.UserName = userName;
        }
        public ShoppingCard()
        {
            
        }
    }
}
