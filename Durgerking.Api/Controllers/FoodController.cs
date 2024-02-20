using Azure.Core;
using Durgerking.Api.Dtos;
using Durgerking.Api.Models;
using Durgerking.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Durgerking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private IProductServise service;

        public FoodController(IProductServise servise)
             => this.service = servise;


        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var request = await service.GetProducts();
            return Ok(request);
        }

        [HttpGet("GetProduct/{Id}")]
        public async Task<IActionResult> GetProduct(int Id)
        {
            var request = await service.GetProduct(Id);
            return Ok(request);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatProduct(CreateProductDto newProduct)
        {
            var request = await service.CreateProduct(newProduct);
            return Ok(request);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var request = await service.DeleteProduct(Id);
            return Ok(request);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct(int id,UpdateProductDto product)
        {
            var request = await service.UpdateProduct(id, product);
            return Ok(request);
        }
    }
}
