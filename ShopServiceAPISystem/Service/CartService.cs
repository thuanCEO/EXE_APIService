using AutoMapper;
using BusinessObjects.Models;
using DTOs;
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

        public async Task<DataResponse<List<ResponseCartDTO>>> GetAllCarts()
        {
            var response = new DataResponse<List<ResponseCartDTO>>();
            try
            {
                var carts = await Task.Run(() => _cartRepository.GetAllCarts());
                response.Data = _mapper.Map<List<ResponseCartDTO>>(carts);
                response.Success = true;
                response.Message = "Carts retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseCartDTO>> GetCartById(int id)
        {
            var response = new DataResponse<ResponseCartDTO>();
            try
            {
                var cart = await Task.Run(() => _cartRepository.GetCartById(id));
                if (cart == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Cart not found.";
                }
                else
                {
                    response.Data = _mapper.Map<ResponseCartDTO>(cart);
                    response.Success = true;
                    response.Message = "Cart retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseCartDTO>> CreateCart(RequestCartDTO cartDTO)
        {
            var response = new DataResponse<ResponseCartDTO>();
            try
            {
                var cart = _mapper.Map<Cart>(cartDTO);
                await Task.Run(() => _cartRepository.CreateCart(cart));
                var createdCart = await Task.Run(() => _cartRepository.GetCartById(cart.Id));
                response.Data = _mapper.Map<ResponseCartDTO>(createdCart);
                response.Success = true;
                response.Message = "Cart created successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }


        public async Task<DataResponse<ResponseCartDTO>> UpdateCart(int id, RequestCartDTO cartDTO)
        {
            var response = new DataResponse<ResponseCartDTO>();
            try
            {
                var cartToUpdate = await Task.Run(() => _cartRepository.GetCartById(id));
                if (cartToUpdate == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Cart not found.";
                }
                else
                {
                    _mapper.Map(cartDTO, cartToUpdate);
                    await Task.Run(() => _cartRepository.UpdateCart(cartToUpdate));
                    var updatedCart = await Task.Run(() => _cartRepository.GetCartById(id));
                    response.Data = _mapper.Map<ResponseCartDTO>(updatedCart);
                    response.Success = true;
                    response.Message = "Cart updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }


        public async Task<DataResponse<string>> DeleteCart(int id)
        {
            var response = new DataResponse<string>();
            try
            {
                var cartToDelete = await Task.Run(() => _cartRepository.GetCartById(id));
                if (cartToDelete == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Cart not found.";
                }
                else
                {
                    await Task.Run(() => _cartRepository.DeleteCart(id));
                    response.Data = "Cart deleted successfully.";
                    response.Success = true;
                    response.Message = "Cart deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseCartDTO>> UpdateCartStatus(int id, int status)
        {
            var response = new DataResponse<ResponseCartDTO>();
            try
            {
                var cart = await Task.Run(() => _cartRepository.GetCartById(id));
                if (cart == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Cart not found.";
                }
                else
                {
                    await Task.Run(() => _cartRepository.UpdateCartStatus(id, status));
                    var updatedCart = await Task.Run(() => _cartRepository.GetCartById(id));
                    response.Data = _mapper.Map<ResponseCartDTO>(updatedCart);
                    response.Success = true;
                    response.Message = "Cart status updated successfully.";
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
