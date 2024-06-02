using AutoMapper;
using BusinessObjects.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs.Cartproducts;
using DTOs;

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

        public async Task<DataResponse<List<ResponseCartProductDTO>>> GetAllCartProducts()
        {
            var response = new DataResponse<List<ResponseCartProductDTO>>();
            try
            {
                var cartProducts = await Task.Run(() => _cartProductRepository.GetAllCartProducts());
                response.Data = _mapper.Map<List<ResponseCartProductDTO>>(cartProducts);
                response.Success = true;
                response.Message = "Cart products retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseCartProductDTO>> GetCartProductById(int id)
        {
            var response = new DataResponse<ResponseCartProductDTO>();
            try
            {
                var cartProduct = await Task.Run(() => _cartProductRepository.GetCartProductById(id));
                if (cartProduct == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Cart product not found.";
                }
                else
                {
                    response.Data = _mapper.Map<ResponseCartProductDTO>(cartProduct);
                    response.Success = true;
                    response.Message = "Cart product retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseCartProductDTO>> CreateCartProduct(RequestCartProductDTO cartProductDTO)
        {
            var response = new DataResponse<ResponseCartProductDTO>();
            try
            {
                var cartProduct = _mapper.Map<CartProduct>(cartProductDTO);
                await Task.Run(() => _cartProductRepository.CreateCartProduct(cartProduct));
                var createdCartProduct = await Task.Run(() => _cartProductRepository.GetCartProductById(cartProduct.Id));
                response.Data = _mapper.Map<ResponseCartProductDTO>(createdCartProduct);
                response.Success = true;
                response.Message = "Cart product created successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseCartProductDTO>> UpdateCartProduct(int id, RequestCartProductDTO cartProductDTO)
        {
            var response = new DataResponse<ResponseCartProductDTO>();
            try
            {
                var cartProductToUpdate = await Task.Run(() => _cartProductRepository.GetCartProductById(id));
                if (cartProductToUpdate == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Cart product not found.";
                }
                else
                {
                    _mapper.Map(cartProductDTO, cartProductToUpdate);
                    await Task.Run(() => _cartProductRepository.UpdateCartProduct(cartProductToUpdate));
                    var updatedCartProduct = await Task.Run(() => _cartProductRepository.GetCartProductById(id));
                    response.Data = _mapper.Map<ResponseCartProductDTO>(updatedCartProduct);
                    response.Success = true;
                    response.Message = "Cart product updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<string>> DeleteCartProduct(int id)
        {
            var response = new DataResponse<string>();
            try
            {
                var cartProductToDelete = await Task.Run(() => _cartProductRepository.GetCartProductById(id));
                if (cartProductToDelete == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Cart product not found.";
                }
                else
                {
                    await Task.Run(() => _cartProductRepository.DeleteCartProduct(id));
                    response.Data = "Cart product deleted successfully.";
                    response.Success = true;
                    response.Message = "Cart product deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseCartProductDTO>> UpdateCartProductStatus(int id, int status)
        {
            var response = new DataResponse<ResponseCartProductDTO>();
            try
            {
                var cartProduct = await Task.Run(() => _cartProductRepository.GetCartProductById(id));
                if (cartProduct == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Cart product not found.";
                }
                else
                {
                    await Task.Run(() => _cartProductRepository.UpdateCartProductStatus(id, status));
                    var updatedCartProduct = await Task.Run(() => _cartProductRepository.GetCartProductById(id));
                    response.Data = _mapper.Map<ResponseCartProductDTO>(updatedCartProduct);
                    response.Success = true;
                    response.Message = "Cart product status updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
