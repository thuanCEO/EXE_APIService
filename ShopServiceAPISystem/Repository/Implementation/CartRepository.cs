using BusinessObjects.Models;
using DataAccessObjects;
using Repository.Interfaces;
using System.Collections.Generic;

namespace Repository.Implementation
{
    public class CartRepository : ICartRepository
    {
        private readonly CartDAO _dao;

        public CartRepository(CartDAO dao)
        {
            _dao = dao;
        }

        public void CreateCart(Cart cart)
        {
            _dao.CreateCart(cart);
        }

        public void UpdateCart(Cart cart)
        {
            _dao.UpdateCart(cart);
        }

        public void DeleteCart(int id)
        {
            _dao.DeleteCart(id);
        }

        public List<Cart> GetAllCarts()
        {
            return _dao.GetAllCarts();
        }

        public Cart GetCartById(int id)
        {
            return _dao.GetCartById(id);
        }

        public void UpdateCartStatus(int id, int status)
        {
            _dao.UpdateCartStatus(id, status);
        }
    }
}