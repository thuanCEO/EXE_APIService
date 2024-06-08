using BusinessObjects.Models;

namespace Repository.Interfaces
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        bool DeleteProduct(int id);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}
