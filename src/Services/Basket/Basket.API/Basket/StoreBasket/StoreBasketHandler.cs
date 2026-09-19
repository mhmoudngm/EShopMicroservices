using Basket.API.Data;
using Basket.API.Models;
using Discount.Grpc;
using MediatR;
using System.Collections;

namespace Basket.API.Basket.StoreBasket
{
    public class StoreBasketHandler : IRequestHandler<StoreBasketCommand, StoreBasketResult>
    {
        private readonly IBasketRepository repo;
        private readonly DiscountProtoService.DiscountProtoServiceClient discountproto;

        public StoreBasketHandler(IBasketRepository repo,DiscountProtoService.DiscountProtoServiceClient discountproto)
        {
            this.repo = repo;
            this.discountproto = discountproto;
        }
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            //store in database and update if exist
            //update cache
            //int[] array = new int[5];
            //ArrayList arraylist = new ArrayList();
            //List<int> list = new List<int>();
            await DeductDiscount(command.card, cancellationToken);
            ShoppingCard card = await repo.StoreBasket(command.card, cancellationToken);
            
            return new StoreBasketResult() { Username = card.UserName };
        }
        private async Task DeductDiscount(ShoppingCard card, CancellationToken cancellationToken)
        {
            foreach (var item in card.Items)    
            {
              var coupon = await discountproto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName },cancellationToken:cancellationToken);
                item.Price -= coupon.Amount;
            }
        }
    }
}
