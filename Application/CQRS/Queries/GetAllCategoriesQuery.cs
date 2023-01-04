using Domain;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<Categories>>
    {
    }
}
