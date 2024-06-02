using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessObjects
{
    public class CartProductDAO
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context;

        public CartProductDAO(bs6ow0djyzdo8teyhoz4Context context)
        {
            _context = context;
        }

        public void CreateCartProduct(CartProduct cartProduct)
        {
            _context.CartProducts.Add(cartProduct);
            _context.SaveChanges();
        }

        public void UpdateCartProduct(CartProduct cartProduct)
        {
            _context.Entry(cartProduct).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCartProduct(int id)
        {
            var cartProduct = _context.CartProducts.Find(id);
            if (cartProduct != null)
            {
                _context.CartProducts.Remove(cartProduct);
                _context.SaveChanges();
            }
        }

        public List<CartProduct> GetAllCartProducts()
        {
            return _context.CartProducts.Include(f => f.Product).ToList();
        }

        public CartProduct GetCartProductById(int id)
        {
            return _context.CartProducts.Include(f => f.Product).FirstOrDefault(cp => cp.Id == id);
        }

        public void UpdateCartProductStatus(int id, int status)
        {
            var cartProduct = _context.CartProducts.Find(id);
            if (cartProduct != null)
            {
                cartProduct.Status = status;
                _context.SaveChanges();
            }
        }
    }
}
