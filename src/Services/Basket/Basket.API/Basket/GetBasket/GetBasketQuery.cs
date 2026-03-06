using MediatR;

namespace Basket.API.Basket.GetBasket
{
    public class GetBasketQuery:IRequest<GetBasketResult>
    {
        public string Username { get; set; } = default!;
    }
}
