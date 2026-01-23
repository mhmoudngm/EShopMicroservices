
using Catalog.API.Models;

namespace Catalog.API.Products.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsResult>
    {
        private IDocumentSession _session;
        private readonly ILogger<GetAllProductsHandler> logger;

        public GetAllProductsHandler(IDocumentSession session,ILogger<GetAllProductsHandler> logger)
        {
            _session = session;
            this.logger = logger;
        }
        public async Task<GetAllProductsResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("get all products");
            var records = await _session.Query<Catalog.API.Models.Product>().ToListAsync(cancellationToken);
            return new GetAllProductsResult()
            {
                Products = records
            };
        }
    }
}
