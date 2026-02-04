
namespace Catalog.API.Products.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
    {
        private readonly IDocumentSession session;
        private readonly ILogger<UpdateProductHandler> logger;

        public UpdateProductHandler(IDocumentSession session, ILogger<UpdateProductHandler> logger)
        {
            this.session = session;
            this.logger = logger;
        }
        public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"update product with this command {request}");
            var product = await session.LoadAsync<Catalog.API.Models.Product>(request.Id);
            if (product is null)
            {
                throw new ProductNotFoundException();
            }
            product.Name = request.Name;
            product.Description = request.Description;
            product.Category = request.Category;
            product.Price = request.Price;
            product.Imagefile = request.Imagefile;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);
            return new UpdateProductResult()
            {
                IsSuccess = true,
            };
        }
    }
}
