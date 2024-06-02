using BusinessObjects.Models;
using DataAccessObjects;
using Repository.Interfaces;
using System.Collections.Generic;

namespace Repository.Implementation
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly ShippingDAO _dao;

        public ShippingRepository(ShippingDAO dao)
        {
            _dao = dao;
        }

        public void CreateShipping(Shipping shipping)
        {
            _dao.CreateShipping(shipping);
        }

        public void UpdateShipping(Shipping shipping)
        {
            _dao.UpdateShipping(shipping);
        }

        public void DeleteShipping(int id)
        {
            _dao.DeleteShipping(id);
        }

        public List<Shipping> GetAllShippings()
        {
            return _dao.GetAllShippings();
        }

        public Shipping GetShippingById(int id)
        {
            return _dao.GetShippingById(id);
        }

        public void UpdateShippingStatus(int id, int status)
        {
            _dao.UpdateShippingStatus(id, status);
        }
    }
}
