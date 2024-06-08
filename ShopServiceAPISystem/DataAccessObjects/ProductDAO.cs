using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

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
            product.Status = 1;
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            Product existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            product.Status = existingProduct.Status;
            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            _context.SaveChanges();
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return false;
            if (product != null)
            {
                product.Status = 0;
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            return true;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products
                .Where(x => x.Status != 0)
                .OrderByDescending(x => x.Id)
                .Include(x => x.Feedbacks)
                .ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products
                .Include(p => p.Feedbacks)
                .ThenInclude(x => x.User)
                .Include(p => p.Category)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
