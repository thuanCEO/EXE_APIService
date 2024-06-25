using BusinessObjects.Models;
using DataAccessObjects;
using Microsoft.AspNetCore.Http;
using Repository.Interfaces;

namespace Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO _dao;
        public ProductRepository(ProductDAO dao)
        {
            _dao = dao;
        }

        public async Task CreateProduct(Product product, IFormFile image)
        {
            await _dao.CreateProduct(product, image);
        }

        public bool DeleteProduct(int id)
        {
            return _dao.DeleteProduct(id);
        }

        public List<Product> GetAllProducts()
        {
            return _dao.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _dao.GetProductById(id);
        }

        public void UpdateProduct(Product product)
        {
            _dao.UpdateProduct(product);
        }
        public int CountProducts(int? status = null)
        {
            return _dao.CountProducts(status);
        }
    }
}
