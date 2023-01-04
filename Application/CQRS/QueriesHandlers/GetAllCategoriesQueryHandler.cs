using Application.CQRS.Queries;
using Application.IRepositories;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Application.CQRS.QueriesHandlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Categories>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ICategoryRepository _ICategoryRepository { get; set; }
        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, ICategoryRepository iCategoryRepository)
        {
            _unitOfWork = unitOfWork;
            _ICategoryRepository = iCategoryRepository;
        }
        public async Task<List<Categories>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            //var cats = _ICategoryRepository.GetCategoriesAsync();
            return await _unitOfWork.Repository<Categories>().GetAllAsync();
        }
    }
}
