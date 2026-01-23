
using Catalog.API.Models;

namespace Catalog.API.Products.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, GetProductResult>
    {
        private readonly IDocumentSession session;
        private readonly ILogger<GetProductHandler> logger;

        public GetProductHandler(IDocumentSession session, ILogger<GetProductHandler> logger)
        {
            this.session = session;
            this.logger = logger;
        }
        public async Task<GetProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("get product by id for this request {@request}", request);
            var result = await session.LoadAsync<Catalog.API.Models.Product>(request.Id, cancellationToken);
            if(result is null)
            {
                throw new ProductNotFoundException();
            }
            return new GetProductResult()
            {
                Id = result.Id,
                Description = result.Description,
                Price = result.Price,
                Name = result.Name,
                Category = result.Category,
                Imagefile = result.Imagefile,
            };
        }
    }
}
