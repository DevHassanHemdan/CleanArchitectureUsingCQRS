using Application.CQRS.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ISender _mediatR;
        public CategoryController(ISender mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet("GetAllCategories")]
        public async Task<List<Categories>> GetAllCategories()
        {
            var response = await _mediatR.Send(new GetAllCategoriesQuery());

            return response;
        }
    }
}
