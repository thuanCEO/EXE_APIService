using BusinessObjects.Models;
using DataAccessObjects;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO _dao;
        public ProductRepository(ProductDAO dao)
        {
            _dao = dao;
        }

        public void CreateProduct(Product product)
        {
            _dao.CreateProduct(product);
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
    }
}
