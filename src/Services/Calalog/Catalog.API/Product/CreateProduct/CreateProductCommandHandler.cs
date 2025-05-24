using MediatR;

namespace Catalog.API.Product.CreateProduct
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //your business here
            throw new NotImplementedException();
        }
    }
}
