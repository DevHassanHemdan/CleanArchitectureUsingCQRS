using Application.CQRS.Commands;
using Application.CQRS.Queries;
using Application.DTOs;
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
        public async Task<List<CategoriesDTO>> GetAllCategories()
        {
            var response = await _mediatR.Send(new GetAllCategoriesQuery());

            return response;
        }

        [HttpPost("CreateProduct")]
        public async Task<CategoriesDTO> CreateProduct([FromBody] CategoriesDTO categoriesDTO)
        {
            var response = await _mediatR.Send(new AddCategoryCommand(categoriesDTO));

            return response;
        }
    }
}
