using AutoMapper;
using BusinessObjects.Models;
using DTOs.Carts;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class CartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseCartDTO>> GetAllCarts()
        {
            var carts = await Task.Run(() => _cartRepository.GetAllCarts());
            return _mapper.Map<List<ResponseCartDTO>>(carts);
        }

        public async Task<ResponseCartDTO> GetCartById(int id)
        {
            var cart = await Task.Run(() => _cartRepository.GetCartById(id));
            if (cart == null)
            {
                return null;
            }
            return _mapper.Map<ResponseCartDTO>(cart);
        }

        public async Task<int> CreateCart(RequestCartDTO cartDTO)
        {
            var cart = _mapper.Map<Cart>(cartDTO);
            await Task.Run(() => _cartRepository.CreateCart(cart));
            return cart.Id;
        }

        public async Task<int> UpdateCart(int id, RequestCartDTO cartDTO)
        {
            var cartToUpdate = await Task.Run(() => _cartRepository.GetCartById(id));
            if (cartToUpdate == null)
            {
                return 0;
            }
            _mapper.Map(cartDTO, cartToUpdate);
            await Task.Run(() => _cartRepository.UpdateCart(cartToUpdate));
            return cartToUpdate.Id;
        }

        public async Task<string> DeleteCart(int id)
        {
            var cartToDelete = await Task.Run(() => _cartRepository.GetCartById(id));
            if (cartToDelete == null)
            {
                return null;
            }
            await Task.Run(() => _cartRepository.DeleteCart(id));
            return "Cart deleted successfully.";
        }

        public async Task<ResponseCartDTO> UpdateCartStatus(int id, int status)
        {
            var cart = await Task.Run(() => _cartRepository.GetCartById(id));
            if (cart == null)
            {
                return null;
            }
            await Task.Run(() => _cartRepository.UpdateCartStatus(id, status));
            var updatedCart = await Task.Run(() => _cartRepository.GetCartById(id));
            return _mapper.Map<ResponseCartDTO>(updatedCart);
        }
    }
}
