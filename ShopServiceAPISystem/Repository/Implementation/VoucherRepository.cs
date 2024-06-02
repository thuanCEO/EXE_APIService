using BusinessObjects.Models;
using DataAccessObjects;
using Repository.Interfaces;
using System.Collections.Generic;

namespace Repository.Implementation
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly VoucherDAO _dao;

        public VoucherRepository(VoucherDAO dao)
        {
            _dao = dao;
        }

        public void CreateVoucher(Voucher voucher)
        {
            _dao.CreateVoucher(voucher);
        }

        public void UpdateVoucher(Voucher voucher)
        {
            _dao.UpdateVoucher(voucher);
        }

        public void DeleteVoucher(int id)
        {
            _dao.DeleteVoucher(id);
        }

        public List<Voucher> GetAllVouchers()
        {
            return _dao.GetAllVouchers();
        }

        public Voucher GetVoucherById(int id)
        {
            return _dao.GetVoucherById(id);
        }

        public void UpdateVoucherStatus(int id, int status)
        {
            _dao.UpdateVoucherStatus(id, status);
        }
    }
}
