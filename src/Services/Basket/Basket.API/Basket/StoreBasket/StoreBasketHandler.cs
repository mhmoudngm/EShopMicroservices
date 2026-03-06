using Basket.API.Data;
using Basket.API.Models;
using MediatR;
using System.Collections;

namespace Basket.API.Basket.StoreBasket
{
    public class StoreBasketHandler : IRequestHandler<StoreBasketCommand, StoreBasketResult>
    {
        private readonly IBasketRepository repo;

        public StoreBasketHandler(IBasketRepository repo)
        {
            this.repo = repo;
        }
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            //store in database and update if exist
            //update cache
            //int[] array = new int[5];
            //ArrayList arraylist = new ArrayList();
            //List<int> list = new List<int>();
            ShoppingCard card = await repo.StoreBasket(command.card, cancellationToken);
            
            return new StoreBasketResult() { Username = card.UserName };
        }
    }
}
