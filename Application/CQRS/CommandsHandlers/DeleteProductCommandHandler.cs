using Application.CQRS.Commands;
using Application.IRepositories;
using MediatR;

namespace Application.CQRS.CommandsHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Products.Delete(request.ProductId);
            return await _unitOfWork.Save();
        }
    }
}
