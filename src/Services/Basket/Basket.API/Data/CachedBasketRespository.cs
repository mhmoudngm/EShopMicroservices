using Basket.API.Models;
using Microsoft.Extensions.Caching.Distributed;
using System.Net.WebSockets;
using System.Text.Json;

namespace Basket.API.Data
{
    public class CachedBasketRespository(IBasketRepository basketRepository, IDistributedCache cache) : IBasketRepository
    {
        //this class implement two design patterns (proxy pattern,decorator pattern)
        public async Task<ShoppingCard> GetBasket(string username, CancellationToken cancellationToken = default)
        {
            var cachedbasket = await cache.GetStringAsync(username, cancellationToken);
            if (!string.IsNullOrEmpty(cachedbasket))
                return JsonSerializer.Deserialize<ShoppingCard>(cachedbasket)!;

            var basket = await basketRepository.GetBasket(username, cancellationToken);
            await cache.SetStringAsync(username, JsonSerializer.Serialize(basket), cancellationToken);
            return basket;
        }
        public async Task<ShoppingCard> StoreBasket(ShoppingCard basket, CancellationToken cancellationToken = default)
        {
            await basketRepository.StoreBasket(basket, cancellationToken);
            await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);
            return basket;
        }
        public async Task<bool> DeleteBasket(string username, CancellationToken cancellationToken = default)
        {
            await basketRepository.DeleteBasket(username, cancellationToken);
            await cache.RemoveAsync(username, cancellationToken);
            return true;
        }
    }
}
