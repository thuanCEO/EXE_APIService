using AutoMapper;
using BusinessObjects.Models;
using DTOs.vouchers;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class VoucherService
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IMapper _mapper;

        public VoucherService(IVoucherRepository voucherRepository, IMapper mapper)
        {
            _voucherRepository = voucherRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseVoucherDTO>> GetAllVouchers()
        {
            var vouchers = await Task.Run(() => _voucherRepository.GetAllVouchers());
            return _mapper.Map<List<ResponseVoucherDTO>>(vouchers);
        }

        public async Task<ResponseVoucherDTO> GetVoucherById(int id)
        {
            var voucher = await Task.Run(() => _voucherRepository.GetVoucherById(id));
            if (voucher == null)
            {
                return null;
            }
            return _mapper.Map<ResponseVoucherDTO>(voucher);
        }

        public async Task<int> CreateVoucher(RequestVoucherDTO voucherDTO)
        {
            var voucher = _mapper.Map<Voucher>(voucherDTO);
            await Task.Run(() => _voucherRepository.CreateVoucher(voucher));
            return voucher.Id;
        }

        public async Task<int> UpdateVoucher(int id, RequestVoucherDTO voucherDTO)
        {
            var voucherToUpdate = await Task.Run(() => _voucherRepository.GetVoucherById(id));
            if (voucherToUpdate == null)
            {
                return 0;
            }
            _mapper.Map(voucherDTO, voucherToUpdate);
            await Task.Run(() => _voucherRepository.UpdateVoucher(voucherToUpdate));
            return voucherToUpdate.Id;
        }

        public async Task<string> DeleteVoucher(int id)
        {
            var voucherToDelete = await Task.Run(() => _voucherRepository.GetVoucherById(id));
            if (voucherToDelete == null)
            {
                return null;
            }
            await Task.Run(() => _voucherRepository.DeleteVoucher(id));
            return "Voucher deleted successfully.";
        }

        public async Task<ResponseVoucherDTO> UpdateVoucherStatus(int id, int status)
        {
            var voucher = await Task.Run(() => _voucherRepository.GetVoucherById(id));
            if (voucher == null)
            {
                return null;
            }
            await Task.Run(() => _voucherRepository.UpdateVoucherStatus(id, status));
            var updatedVoucher = await Task.Run(() => _voucherRepository.GetVoucherById(id));
            return _mapper.Map<ResponseVoucherDTO>(updatedVoucher);
        }
    }
}
