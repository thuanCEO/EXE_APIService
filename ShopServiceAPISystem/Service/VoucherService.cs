using AutoMapper;
using BusinessObjects.Models;
using DTOs;
using DTOs.vouchers;
using Repository.Implementation;
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

        public async Task<DataResponse<List<ResponseVoucherDTO>>> GetAllVouchers()
        {
            var response = new DataResponse<List<ResponseVoucherDTO>>();
            try
            {
                var vouchers = await Task.Run(() => _voucherRepository.GetAllVouchers());
                response.Data = _mapper.Map<List<ResponseVoucherDTO>>(vouchers);
                response.Success = true;
                response.Message = "Vouchers retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseVoucherDTO>> GetVoucherById(int id)
        {
            var response = new DataResponse<ResponseVoucherDTO>();
            try
            {
                var voucher = await Task.Run(() => _voucherRepository.GetVoucherById(id));
                if (voucher == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Voucher not found.";
                }
                else
                {
                    response.Data = _mapper.Map<ResponseVoucherDTO>(voucher);
                    response.Success = true;
                    response.Message = "Voucher retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<int>> CreateVoucher(RequestVoucherDTO voucherDTO)
        {
            var response = new DataResponse<int>();
            try
            {
                var voucher = _mapper.Map<Voucher>(voucherDTO);
                await Task.Run(() => _voucherRepository.CreateVoucher(voucher));
                response.Data = _mapper.Map<ResponseVoucherDTO>(voucher);
                response.Success = true;
                response.Message = "Voucher created successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<int>> UpdateVoucher(int id, RequestVoucherDTO voucherDTO)
        {
            var response = new DataResponse<int>();
            try
            {
                var voucherToUpdate = await Task.Run(() => _voucherRepository.GetVoucherById(id));
                if (voucherToUpdate == null)
                {
                    response.Data = 0;
                    response.Success = false;
                    response.Message = "Voucher not found.";
                }
                else
                {
                    _mapper.Map(voucherDTO, voucherToUpdate);
                    await Task.Run(() => _voucherRepository.UpdateVoucher(voucherToUpdate));
                    response.Data = _mapper.Map<ResponseVoucherDTO>(voucherToUpdate);
                    response.Success = true;
                    response.Message = "Voucher updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<string>> DeleteVoucher(int id)
        {
            var response = new DataResponse<string>();
            try
            {
                var serviceToDelete = await Task.Run(() => _voucherRepository.GetVoucherById(id));
                if (serviceToDelete == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Voucher not found.";
                }
                else
                {
                    await Task.Run(() => _voucherRepository.DeleteVoucher(id));
                    response.Data = "Voucher deleted successfully.";
                    response.Success = true;
                    response.Message = "Voucher deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Something went wrong. Please try again.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseVoucherDTO>> UpdateVoucherStatus(int id, int status)
        {
            var response = new DataResponse<ResponseVoucherDTO>();
            try
            {
                var voucher = await Task.Run(() => _voucherRepository.GetVoucherById(id));
                if (voucher == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Voucher not found.";
                }
                else
                {
                    await Task.Run(() => _voucherRepository.UpdateVoucherStatus(id, status));
                    var updatedVoucher = await Task.Run(() => _voucherRepository.GetVoucherById(id));
                    response.Data = _mapper.Map<ResponseVoucherDTO>(updatedVoucher);
                    response.Success = true;
                    response.Message = "Voucher status updated successfully.";
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
