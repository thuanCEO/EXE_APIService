using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface ICartProductRepository
    {
        void CreateCartProduct(CartProduct cartProduct);
        void UpdateCartProduct(CartProduct cartProduct);
        void DeleteCartProduct(int id);
        List<CartProduct> GetAllCartProducts();
        CartProduct GetCartProductById(int id);
        void UpdateCartProductStatus(int id, int status);
    }
}
