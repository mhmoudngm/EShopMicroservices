
using Catalog.API.Models;
using Marten.Pagination;

namespace Catalog.API.Products.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsResult>
    {
        private IDocumentSession _session;
        private readonly ILogger<GetAllProductsHandler> logger;

        public GetAllProductsHandler(IDocumentSession session, ILogger<GetAllProductsHandler> logger)
        {
            _session = session;
            this.logger = logger;
        }
        public async Task<GetAllProductsResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("get all products");
            var records = await _session.Query<Catalog.API.Models.Product>().ToPagedListAsync(request.PageNumber ?? 1, request.PageSize ?? 10, cancellationToken);
            return new GetAllProductsResult()
            {
                Products = records
            };
        }
    }
}
