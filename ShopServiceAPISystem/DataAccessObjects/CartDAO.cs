using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class CartDAO
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context = new bs6ow0djyzdo8teyhoz4Context();

        public CartDAO()
        {
        }

        public void CreateCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }

        public void UpdateCart(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCart(int id)
        {
            var cart = _context.Carts.Find(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                _context.SaveChanges();
            }
        }

        public List<Cart> GetAllCarts()
        {
            return _context.Carts.Include(c => c.User).ToList();
        }

        public Cart GetCartById(int id)
        {
            return _context.Carts.Include(c => c.User).FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCartStatus(int id, int status)
        {
            var cart = _context.Carts.Find(id);
            if (cart != null)
            {
                cart.Status = status;
                _context.SaveChanges();
            }
        }
    }
}
