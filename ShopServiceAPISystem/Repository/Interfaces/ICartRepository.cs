using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface ICartRepository
    {
        void CreateCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(int id);
        List<Cart> GetAllCarts();
        Cart GetCartById(int id);
        void UpdateCartStatus(int id, int status);
    }
}
