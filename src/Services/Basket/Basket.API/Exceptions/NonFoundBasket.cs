namespace Basket.API.Exceptions
{
    public class NonFoundBasket:Exception
    {
        public NonFoundBasket(string username) : base($"basket with user name {username} not found")
        {
            
        }
    }
}
