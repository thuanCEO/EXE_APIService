using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
