using AutoMapper;
using BusinessObjects.Models;
using DTOs;
using DTOs.shippings;
using Repository.Implementation;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class ShippingService
    {
        private readonly IShippingRepository _shippingRepository;
        private readonly IMapper _mapper;

        public ShippingService(IShippingRepository shippingRepository, IMapper mapper)
        {
            _shippingRepository = shippingRepository;
            _mapper = mapper;
        }

        public async Task<DataResponse<List<ResponseShippingDTO>>> GetAllShippings()
        {
            var response = new DataResponse<List<ResponseShippingDTO>>();
            try
            {
                var shippings = await Task.Run(() => _shippingRepository.GetAllShippings());
                response.Data = _mapper.Map<List<ResponseShippingDTO>>(shippings);
                response.Success = true;
                response.Message = "Shippings retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseShippingDTO>> GetShippingById(int id)
        {
            var response = new DataResponse<ResponseShippingDTO>();
            try
            {
                var shipping = await Task.Run(() => _shippingRepository.GetShippingById(id));
                if (shipping == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Shipping not found.";
                }
                else
                {
                    response.Data = _mapper.Map<ResponseShippingDTO>(shipping);
                    response.Success = true;
                    response.Message = "Shipping retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<int>> CreateShipping(RequestShippingDTO shippingDTO)
        {
            var response = new DataResponse<int>();
            try
            {
                var shipping = _mapper.Map<Shipping>(shippingDTO);
                await Task.Run(() => _shippingRepository.CreateShipping(shipping));
                response.Data = _mapper.Map<ResponseShippingDTO>(shipping);
                response.Success = true;
                response.Message = "Shipping created successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<int>> UpdateShipping(int id, RequestShippingDTO shippingDTO)
        {
            var response = new DataResponse<int>();
            try
            {
                var shippingToUpdate = await Task.Run(() => _shippingRepository.GetShippingById(id));
                if (shippingToUpdate == null)
                {
                    response.Data = 0;
                    response.Success = false;
                    response.Message = "Shipping not found.";
                }
                else
                {
                    _mapper.Map(shippingDTO, shippingToUpdate);
                    await Task.Run(() => _shippingRepository.UpdateShipping(shippingToUpdate));
                    response.Data = _mapper.Map<ResponseShippingDTO>(shippingToUpdate);
                    response.Success = true;
                    response.Message = "Shipping updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<string>> DeleteShipping(int id)
        {
            var response = new DataResponse<string>();
            try
            {
                var serviceToDelete = await Task.Run(() => _shippingRepository.GetShippingById(id));
                if (serviceToDelete == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Shipping not found.";
                }
                else
                {
                    await Task.Run(() => _shippingRepository.DeleteShipping(id));
                    response.Data = "Shipping deleted successfully.";
                    response.Success = true;
                    response.Message = "Shipping deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseShippingDTO>> UpdateShippingStatus(int id, int status)
        {
            var response = new DataResponse<ResponseShippingDTO>();
            try
            {
                var shipping = await Task.Run(() => _shippingRepository.GetShippingById(id));
                if (shipping == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Shipping not found.";
                }
                else
                {
                    await Task.Run(() => _shippingRepository.UpdateShippingStatus(id, status));
                    var updatedShipping = await Task.Run(() => _shippingRepository.GetShippingById(id));
                    response.Data = _mapper.Map<ResponseShippingDTO>(updatedShipping);
                    response.Success = true;
                    response.Message = "Shipping status updated successfully.";
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
