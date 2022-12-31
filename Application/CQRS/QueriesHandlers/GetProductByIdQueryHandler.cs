using Application.CQRS.Queries;
using Application.IRepositories;
using Domain;
using MediatR;

namespace Application.CQRS.QueriesHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product product = await _unitOfWork.Products.Get(x => x.Id == request.ProductId);
            return product;
        }
    }
}
