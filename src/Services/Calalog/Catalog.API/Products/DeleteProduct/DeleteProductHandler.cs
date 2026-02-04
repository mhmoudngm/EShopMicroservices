
using Catalog.API.Models;

namespace Catalog.API.Products.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResult>
    {
        private readonly IDocumentSession session;
        private readonly ILogger<DeleteProductHandler> logger;

        public DeleteProductHandler(IDocumentSession session,ILogger<DeleteProductHandler> logger)
        {
            this.session = session;
            this.logger = logger;
        }
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Delete product with this info {command}");
            //var product = await session.LoadAsync<Catalog.API.Models.Product>(command.Id);
            //if (product is null)
            //{
            //    throw new ProductNotFoundException();
            //}
            //session.Delete(product);
            session.Delete<Catalog.API.Models.Product>(command.Id);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult()
            {
                IsDeleted = true,
            };
        }
    }
}
