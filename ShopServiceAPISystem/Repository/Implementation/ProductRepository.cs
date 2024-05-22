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


        public List<Product> GetAllProducts()
        {
            return _dao.GetAllProducts();
        }
    }
}
