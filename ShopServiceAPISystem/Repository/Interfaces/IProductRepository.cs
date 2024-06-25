using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;

namespace Repository.Interfaces
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product, IFormFile image);
        void UpdateProduct(Product product);
        bool DeleteProduct(int id);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        int CountProducts(int? status = null);
    }
}
