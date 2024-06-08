using BusinessObjects.Models;
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

        public void CreateProduct(Product product)
        {
            _productRepository.CreateProduct(product);
        }
        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }
        public bool DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }
    }
}
