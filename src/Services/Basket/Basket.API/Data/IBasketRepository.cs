using Basket.API.Models;

namespace Basket.API.Data
{
    public interface IBasketRepository
    {
        Task<ShoppingCard> GetBasket(string username,CancellationToken cancellationToken = default);
        Task<ShoppingCard> StoreBasket(ShoppingCard card,CancellationToken cancellationToken=default);
        Task<bool> DeleteBasket(string username,CancellationToken cancellationToken=default);
    }
}
