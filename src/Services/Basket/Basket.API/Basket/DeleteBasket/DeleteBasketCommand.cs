using MediatR;

namespace Basket.API.Basket.DeleteBasket
{
    public class DeleteBasketCommand:IRequest<DeleteBasketResult>
    {
        public string Username { get; set; }
    }
}
