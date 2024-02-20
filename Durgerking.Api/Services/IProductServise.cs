using Durgerking.Api.Dtos;
using Durgerking.Api.Models;

namespace Durgerking.Api.Services
{
    public interface IProductServise
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<Product> CreateProduct(CreateProductDto newProduct);
        Task<bool> DeleteProduct(int id);
        Task<Product> UpdateProduct(int id, UpdateProductDto Product);
    }
}
