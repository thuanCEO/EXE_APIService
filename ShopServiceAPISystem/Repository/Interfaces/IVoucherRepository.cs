using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IVoucherRepository
    {
        void CreateVoucher(Voucher voucher);
        void UpdateVoucher(Voucher voucher);
        void DeleteVoucher(int id);
        List<Voucher> GetAllVouchers();
        Voucher GetVoucherById(int id);
        void UpdateVoucherStatus(int id, int status);
    }
}
