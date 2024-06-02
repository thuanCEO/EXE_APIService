using BusinessObjects.Models;
using DataAccessObjects;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementation
{
    public class CartProductRepository : ICartProductRepository
    {
        private readonly CartProductDAO _dao;

        public CartProductRepository(CartProductDAO dao)
        {
            _dao = dao;
        }

        public void CreateCartProduct(CartProduct cartProduct)
        {
            _dao.CreateCartProduct(cartProduct);
        }

        public void UpdateCartProduct(CartProduct cartProduct)
        {
            _dao.UpdateCartProduct(cartProduct);
        }

        public void DeleteCartProduct(int id)
        {
            _dao.DeleteCartProduct(id);
        }

        public List<CartProduct> GetAllCartProducts()
        {
            return _dao.GetAllCartProducts();
        }

        public CartProduct GetCartProductById(int id)
        {
            return _dao.GetCartProductById(id);
        }

        public void UpdateCartProductStatus(int id, int status)
        {
            _dao.UpdateCartProductStatus(id, status);
        }
    }
}
