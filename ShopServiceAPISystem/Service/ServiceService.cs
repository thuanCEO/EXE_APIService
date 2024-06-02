using AutoMapper;
using BusinessObjects.Models;
using DTOs;
using DTOs.Services;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<DataResponse<List<ResponseServiceDTO>>> GetAllServices()
        {
            var response = new DataResponse<List<ResponseServiceDTO>>();
            try
            {
                var services = await Task.Run(() => _serviceRepository.GetAllServices());
                response.Data = _mapper.Map<List<ResponseServiceDTO>>(services);
                response.Success = true;
                response.Message = "Services retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseServiceDTO>> GetServiceById(int id)
        {
            var response = new DataResponse<ResponseServiceDTO>();
            try
            {
                var service = await Task.Run(() => _serviceRepository.GetServiceById(id));
                if (service == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Service not found.";
                }
                else
                {
                    response.Data = _mapper.Map<ResponseServiceDTO>(service);
                    response.Success = true;
                    response.Message = "Service retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<int>> CreateService(RequestServiceDTO serviceDTO)
        {
            var response = new DataResponse<int>();
            try
            {
                var service = _mapper.Map<BusinessObjects.Models.Service>(serviceDTO);
                await Task.Run(() => _serviceRepository.CreateService(service));
                response.Data = _mapper.Map<ResponseServiceDTO>(service);
                response.Success = true;
                response.Message = "Service created successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<int>> UpdateService(int id, RequestServiceDTO serviceDTO)
        {
            var response = new DataResponse<int>();
            try
            {
                var serviceToUpdate = await Task.Run(() => _serviceRepository.GetServiceById(id));
                if (serviceToUpdate == null)
                {
                    response.Data = 0;
                    response.Success = false;
                    response.Message = "Service not found.";
                }
                else
                {
                    _mapper.Map(serviceDTO, serviceToUpdate);
                    await Task.Run(() => _serviceRepository.UpdateService(serviceToUpdate));
                    response.Data = _mapper.Map<ResponseServiceDTO>(serviceToUpdate);
                    response.Success = true;
                    response.Message = "Service updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<string>> DeleteService(int id)
        {
            var response = new DataResponse<string>();
            try
            {
                var serviceToDelete = await Task.Run(() => _serviceRepository.GetServiceById(id));
                if (serviceToDelete == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Service not found.";
                }
                else
                {
                    await Task.Run(() => _serviceRepository.DeleteService(id));
                    response.Data = "Service deleted successfully.";
                    response.Success = true;
                    response.Message = "Service deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseServiceDTO>> UpdateServiceStatus(int id, int status)
        {
            var response = new DataResponse<ResponseServiceDTO>();
            try
            {
                var service = await Task.Run(() => _serviceRepository.GetServiceById(id));
                if (service == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Service not found.";
                }
                else
                {
                    await Task.Run(() => _serviceRepository.UpdateServiceStatus(id, status));
                    var updatedService = await Task.Run(() => _serviceRepository.GetServiceById(id));
                    response.Data = _mapper.Map<ResponseServiceDTO>(updatedService);
                    response.Success = true;
                    response.Message = "Service status updated successfully.";
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
