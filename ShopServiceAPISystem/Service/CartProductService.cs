using AutoMapper;
using BusinessObjects.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs.Cartproducts;

namespace Service
{
    public class CartProductService
    {
        private readonly ICartProductRepository _cartProductRepository;
        private readonly IMapper _mapper;

        public CartProductService(ICartProductRepository cartProductRepository, IMapper mapper)
        {
            _cartProductRepository = cartProductRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseCartProductDTO>> GetAllCartProducts()
        {
            var cartProducts = await Task.Run(() => _cartProductRepository.GetAllCartProducts());
            return _mapper.Map<List<ResponseCartProductDTO>>(cartProducts);
        }

        public async Task<ResponseCartProductDTO> GetCartProductById(int id)
        {
            var cartProduct = await Task.Run(() => _cartProductRepository.GetCartProductById(id));
            if (cartProduct == null)
            {
                return null;
            }
            return _mapper.Map<ResponseCartProductDTO>(cartProduct);
        }

        public async Task<int> CreateCartProduct(RequestCartProductDTO cartProductDTO)
        {
            var cartProduct = _mapper.Map<CartProduct>(cartProductDTO);
            await Task.Run(() => _cartProductRepository.CreateCartProduct(cartProduct));
            return cartProduct.Id;
        }

        public async Task<int> UpdateCartProduct(int id, RequestCartProductDTO cartProductDTO)
        {
            var cartProductToUpdate = await Task.Run(() => _cartProductRepository.GetCartProductById(id));
            if (cartProductToUpdate == null)
            {
                return 0;
            }
            _mapper.Map(cartProductDTO, cartProductToUpdate);
            await Task.Run(() => _cartProductRepository.UpdateCartProduct(cartProductToUpdate));
            return cartProductToUpdate.Id;
        }

        public async Task<bool> DeleteCartProduct(int id)
        {
            var cartProductToDelete = await Task.Run(() => _cartProductRepository.GetCartProductById(id));
            if (cartProductToDelete == null)
            {
                return false;
            }
            await Task.Run(() => _cartProductRepository.DeleteCartProduct(id));
            return true;
        }

        public async Task<ResponseCartProductDTO> UpdateCartProductStatus(int id, int status)
        {
            var cartProduct = await Task.Run(() => _cartProductRepository.GetCartProductById(id));
            if (cartProduct == null)
            {
                return null;
            }
            await Task.Run(() => _cartProductRepository.UpdateCartProductStatus(id, status));
            var updatedCartProduct = await Task.Run(() => _cartProductRepository.GetCartProductById(id));
            return _mapper.Map<ResponseCartProductDTO>(updatedCartProduct);
        }
    }
}
