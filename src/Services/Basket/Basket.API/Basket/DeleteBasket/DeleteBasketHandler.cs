using Basket.API.Data;
using MediatR;

namespace Basket.API.Basket.DeleteBasket
{
    public class DeleteBasketHandler : IRequestHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        private readonly IBasketRepository repo;

        public DeleteBasketHandler(IBasketRepository repo)
        {
            this.repo = repo;
        }
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            var result = await repo.DeleteBasket(request.Username, cancellationToken);
            return new DeleteBasketResult()
            {
                IsDeleted = result
            };
        }
    }
}
