using Basket.API.Exceptions;
using Basket.API.Models;
using Marten;

namespace Basket.API.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDocumentSession session;

        public BasketRepository(IDocumentSession session)
        {
            this.session = session;
        }


        public async Task<ShoppingCard> GetBasket(string username, CancellationToken cancellationToken = default)
        {
            var basket = await session.LoadAsync<ShoppingCard>(username, cancellationToken);
            return basket is null ? throw new NonFoundBasket(username) : basket;
        }

        public async Task<ShoppingCard> StoreBasket(ShoppingCard card, CancellationToken cancellationToken = default)
        {
            session.Store(card);
            await session.SaveChangesAsync(cancellationToken);
            return card;
        }
        public async Task<bool> DeleteBasket(string username, CancellationToken cancellationToken = default)
        {
            session.Delete<ShoppingCard>(username);
            await session.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}
