using Basket.API.Data;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Basket.API.Basket.GetBasket
{
    public class GetBasketHandler : IRequestHandler<GetBasketQuery, GetBasketResult>
    {
        private readonly IBasketRepository repo;

        public GetBasketHandler(IBasketRepository repo)
        {
            this.repo = repo;
        }
        public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var result= await repo.GetBasket(request.Username, cancellationToken);
            return new GetBasketResult(){ card=result};
        }
    }
}
