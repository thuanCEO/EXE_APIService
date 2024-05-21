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

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Product> GetAllProduct()
        {
            return _context.Products.Where(x => x.Status == 1)
                .OrderByDescending(x =>x.Id)
                .Include(p => p.Feedbacks)
                .Include(p => p.Category)
                .ToList();
        }
        
         
    }
}
