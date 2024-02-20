using Durgerking.Api.Data;
using Durgerking.Api.Dtos;
using Durgerking.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Durgerking.Api.Services
{
    public class ProductService : IProductServise
    {
        private readonly AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> CreateProduct(CreateProductDto newProduct)
        {
            var product = new Product()
            {
                Name = newProduct.Name,
                Price = newProduct.Price,
                Quantity = newProduct.Quantity,
                Description = newProduct.Description,
                Created = DateTime.UtcNow.AddHours(5)
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
                return false;

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
                return null;

            return product;
        }

        public async Task<List<Product>> GetProducts()
            => await _dbContext.Products.ToListAsync();

        public async Task<Product> UpdateProduct(int id, UpdateProductDto Product)
        {
            var update = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if(update is null)
                return null;

            update.Name = Product.Name;
            update.Price = Product.Price;
            update.Description = Product.Description;
            update.Quantity = Product.Quantity;
            update.Updated = DateTime.UtcNow.AddHours(5);

            await _dbContext.SaveChangesAsync();
            return update;
        }
    }
}
