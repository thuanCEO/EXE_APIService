using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IServiceRepository
    {
        void CreateService(Service service);
        void UpdateService(Service service);
        void DeleteService(int id);
        List<Service> GetAllServices();
        Service GetServiceById(int id);
        void UpdateServiceStatus(int id, int status);
    }
}
