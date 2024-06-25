using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Repository.Interfaces;

namespace Service
{
    public class ProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public async Task CreateProduct(Product product, IFormFile image)
        {
            await _productRepository.CreateProduct(product, image);
        }
        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }
        public bool DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }
        public int CountProducts(int? status = null)
        {
            return _productRepository.CountProducts(status);
        }
    }
}
