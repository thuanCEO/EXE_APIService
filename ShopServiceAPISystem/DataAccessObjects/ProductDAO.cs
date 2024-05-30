using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context;
        public ProductDAO(bs6ow0djyzdo8teyhoz4Context context)
        {
            _context = context;
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            Product existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            // Đánh dấu thực thể là đã được chỉnh sửa
            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            _context.SaveChanges();
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if(product == null)
                return false;
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return true;
        }

           public List<Product> GetAllProducts()
        {
            return _context.Products
                .OrderByDescending(x =>x.Id)
                .Include(x => x.Feedbacks)
                .Include(x => x.Category)
                .ToList();
        }

        public Product GetProductByID(int id)
        {
            return _context.Products
                .Include(p => p.Feedbacks)
                .Include(p => p.Category)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
