using AutoMapper;
using BusinessObjects.Models;
using DTOs.Services;
using Repository.Interfaces;
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

        public async Task<List<ResponseServiceDTO>> GetAllServices()
        {
            var services = await Task.Run(() => _serviceRepository.GetAllServices());
            return _mapper.Map<List<ResponseServiceDTO>>(services);
        }

        public async Task<ResponseServiceDTO> GetServiceById(int id)
        {
            var service = await Task.Run(() => _serviceRepository.GetServiceById(id));
            if (service == null)
            {
                return null;
            }
            return _mapper.Map<ResponseServiceDTO>(service);
        }

        public async Task<int> CreateService(RequestServiceDTO serviceDTO)
        {
            var service = _mapper.Map<BusinessObjects.Models.Service>(serviceDTO);
            await Task.Run(() => _serviceRepository.CreateService(service));
            return service.Id;
        }

        public async Task<int> UpdateService(int id, RequestServiceDTO serviceDTO)
        {
            var serviceToUpdate = await Task.Run(() => _serviceRepository.GetServiceById(id));
            if (serviceToUpdate == null)
            {
                return 0;
            }
            _mapper.Map(serviceDTO, serviceToUpdate);
            await Task.Run(() => _serviceRepository.UpdateService(serviceToUpdate));
            return serviceToUpdate.Id;
        }

        public async Task<string> DeleteService(int id)
        {
            var serviceToDelete = await Task.Run(() => _serviceRepository.GetServiceById(id));
            if (serviceToDelete == null)
            {
                return null;
            }
            await Task.Run(() => _serviceRepository.DeleteService(id));
            return "Service deleted successfully.";
        }

        public async Task<ResponseServiceDTO> UpdateServiceStatus(int id, int status)
        {
            var service = await Task.Run(() => _serviceRepository.GetServiceById(id));
            if (service == null)
            {
                return null;
            }
            await Task.Run(() => _serviceRepository.UpdateServiceStatus(id, status));
            var updatedService = await Task.Run(() => _serviceRepository.GetServiceById(id));
            return _mapper.Map<ResponseServiceDTO>(updatedService);
        }
    }
}
