using Application.CQRS.Commands;
using Application.DTOs;
using Application.IRepositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.CQRS.CommandsHandlers
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = _mapper.Map<Product>(request._product);
                await _unitOfWork.Products.Insert(product);
                await _unitOfWork.Save();
                return request._product;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
