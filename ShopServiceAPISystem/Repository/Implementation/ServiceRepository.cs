using BusinessObjects.Models;
using DataAccessObjects;
using Repository.Interfaces;
using System.Collections.Generic;

namespace Repository.Implementation
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ServiceDAO _dao;

        public ServiceRepository(ServiceDAO dao)
        {
            _dao = dao;
        }

        public void CreateService(Service service)
        {
            _dao.CreateService(service);
        }

        public void UpdateService(Service service)
        {
            _dao.UpdateService(service);
        }

        public void DeleteService(int id)
        {
            _dao.DeleteService(id);
        }

        public List<Service> GetAllServices()
        {
            return _dao.GetAllServices();
        }

        public Service GetServiceById(int id)
        {
            return _dao.GetServiceById(id);
        }

        public void UpdateServiceStatus(int id, int status)
        {
            _dao.UpdateServiceStatus(id, status);
        }
    }
}
