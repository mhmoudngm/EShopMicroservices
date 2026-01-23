
namespace Catalog.API.Products.GetProductBycategory
{
    public class GetProductByCategoryHandler : IRequestHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        private readonly IDocumentSession session;
        private readonly ILogger<GetProductByCategoryHandler> logger;

        public GetProductByCategoryHandler(IDocumentSession session,ILogger<GetProductByCategoryHandler> logger)
        {
            this.session = session;
            this.logger = logger;
        }
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await session.Query<Catalog.API.Models.Product>().Where(i=>i.Category.Contains(request.Category)).ToListAsync(cancellationToken);
            return new GetProductByCategoryResult()
            {
                Products = result,
            };
        }
    }
}
