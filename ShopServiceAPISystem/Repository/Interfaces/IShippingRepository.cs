using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IShippingRepository
    {
        void CreateShipping(Shipping shipping);
        void UpdateShipping(Shipping shipping);
        void DeleteShipping(int id);
        List<Shipping> GetAllShippings();
        Shipping GetShippingById(int id);
        void UpdateShippingStatus(int id, int status);
    }
}
