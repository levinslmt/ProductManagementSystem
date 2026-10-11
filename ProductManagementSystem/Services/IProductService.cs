using ProductManagementSystem.Models;

namespace ProductManagementSystem.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product?> GetProductById(int id);
        Task<Product> CreateProduct(Product product);
        Task<Product?> UpdateProduct(int id, Product updatedProduct);
        Task<bool> DeleteProduct(int id);
    }
}
