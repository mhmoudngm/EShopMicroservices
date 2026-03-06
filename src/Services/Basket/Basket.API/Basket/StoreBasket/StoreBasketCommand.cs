using Basket.API.Models;
using MediatR;

namespace Basket.API.Basket.StoreBasket
{
    public class StoreBasketCommand:IRequest<StoreBasketResult>
    {
        public ShoppingCard card { get; set; }
    }
}
