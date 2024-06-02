using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class ShippingDAO
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context;

        public ShippingDAO(bs6ow0djyzdo8teyhoz4Context context)
        {
            _context = context;
        }

        public void CreateShipping(Shipping shipping)
        {
            _context.Shippings.Add(shipping);
            _context.SaveChanges();
        }

        public void UpdateShipping(Shipping shipping)
        {
            _context.Entry(shipping).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteShipping(int id)
        {
            var shipping = _context.Shippings.Find(id);
            if (shipping != null)
            {
                _context.Shippings.Remove(shipping);
                _context.SaveChanges();
            }
        }

        public List<Shipping> GetAllShippings()
        {
            return _context.Shippings.ToList();
        }

        public Shipping GetShippingById(int id)
        {
            return _context.Shippings.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateShippingStatus(int id, int status)
        {
            var shipping = _context.Shippings.Find(id);
            if (shipping != null)
            {
                shipping.Status = status;
                _context.SaveChanges();
            }
        }
    }
}
