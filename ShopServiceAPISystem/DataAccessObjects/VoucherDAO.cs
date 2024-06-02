using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class VoucherDAO
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context;

        public VoucherDAO(bs6ow0djyzdo8teyhoz4Context context)
        {
            _context = context;
        }

        public void CreateVoucher(Voucher voucher)
        {
            _context.Vouchers.Add(voucher);
            _context.SaveChanges();
        }

        public void UpdateVoucher(Voucher voucher)
        {
            _context.Entry(voucher).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteVoucher(int id)
        {
            var voucher = _context.Vouchers.Find(id);
            if (voucher != null)
            {
                _context.Vouchers.Remove(voucher);
                _context.SaveChanges();
            }
        }

        public List<Voucher> GetAllVouchers()
        {
            return _context.Vouchers.ToList();
        }

        public Voucher GetVoucherById(int id)
        {
            return _context.Vouchers.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateVoucherStatus(int id, int status)
        {
            var voucher = _context.Vouchers.Find(id);
            if (voucher != null)
            {
                voucher.Status = status;
                _context.SaveChanges();
            }
        }
    }
}
