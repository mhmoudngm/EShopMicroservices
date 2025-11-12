

namespace Catalog.API.Product.CreateProduct
{
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IDocumentSession session;

        public CreateProductCommandHandler(IDocumentSession session)
        {
            this.session = session;
        }
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //your business here
            var product = new Catalog.API.Models.Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                Imagefile = command.Imagefile,
                Price = command.Price,
            };
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            //save to database
            return new CreateProductResult
            {
                Id = product.Id,
            };
        }
    }
}
