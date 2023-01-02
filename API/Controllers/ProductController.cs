using Application.CQRS.Commands;
using Application.CQRS.Queries;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController
    {
        private readonly ISender _mediatR;
        public ProductController(ISender mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpGet("GetAllProducts")]
        public async Task<List<Product>> GetAllProducts()
        {
            var response = await _mediatR.Send(new GetAllProductsQuery());

            return response;
        }
        [HttpGet("{id}")]
        public async Task<Product> GetProductById(Guid id)
        {
            var response = await _mediatR.Send(new GetProductByIdQuery(id));

            return response;
        }
        [HttpPost("CreateProduct")]
        public async Task<ProductDTO> CreateProduct(ProductDTO productDTo)
        {
            var response = await _mediatR.Send(new AddProductCommand(productDTo));

            return productDTo;
        }
        [HttpPost("DeleteProduct")]
        public async Task<int> DeleteProduct(Guid productId)
        {
            return await _mediatR.Send(new DeleteProductCommand(productId));
        }
    }
}