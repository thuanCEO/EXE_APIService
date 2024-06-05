using AutoMapper;
using BusinessObjects.Models;
using DTOs.shippings;
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

        public async Task<List<ResponseShippingDTO>> GetAllShippings()
        {
            var shippings = await Task.Run(() => _shippingRepository.GetAllShippings());
            return _mapper.Map<List<ResponseShippingDTO>>(shippings);
        }

        public async Task<ResponseShippingDTO> GetShippingById(int id)
        {
            var shipping = await Task.Run(() => _shippingRepository.GetShippingById(id));
            if (shipping == null)
            {
                return null;
            }
            return _mapper.Map<ResponseShippingDTO>(shipping);
        }

        public async Task<int> CreateShipping(RequestShippingDTO shippingDTO)
        {
            var shipping = _mapper.Map<Shipping>(shippingDTO);
            await Task.Run(() => _shippingRepository.CreateShipping(shipping));
            return shipping.Id;
        }

        public async Task<int> UpdateShipping(int id, RequestShippingDTO shippingDTO)
        {
            var shippingToUpdate = await Task.Run(() => _shippingRepository.GetShippingById(id));
            if (shippingToUpdate == null)
            {
                return 0;
            }
            _mapper.Map(shippingDTO, shippingToUpdate);
            await Task.Run(() => _shippingRepository.UpdateShipping(shippingToUpdate));
            return shippingToUpdate.Id;
        }

        public async Task<string> DeleteShipping(int id)
        {
            var shippingToDelete = await Task.Run(() => _shippingRepository.GetShippingById(id));
            if (shippingToDelete == null)
            {
                return null;
            }
            await Task.Run(() => _shippingRepository.DeleteShipping(id));
            return "Shipping deleted successfully.";
        }

        public async Task<ResponseShippingDTO> UpdateShippingStatus(int id, int status)
        {
            var shipping = await Task.Run(() => _shippingRepository.GetShippingById(id));
            if (shipping == null)
            {
                return null;
            }
            await Task.Run(() => _shippingRepository.UpdateShippingStatus(id, status));
            var updatedShipping = await Task.Run(() => _shippingRepository.GetShippingById(id));
            return _mapper.Map<ResponseShippingDTO>(updatedShipping);
        }
    }
}
