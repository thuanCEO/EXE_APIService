using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class ServiceDAO
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context;

        public ServiceDAO(bs6ow0djyzdo8teyhoz4Context context)
        {
            _context = context;
        }

        public void CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void UpdateService(Service service)
        {
            _context.Entry(service).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteService(int id)
        {
            var service = _context.Services.Find(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
        }

        public List<Service> GetAllServices()
        {
            return _context.Services.ToList();
        }

        public Service GetServiceById(int id)
        {
            return _context.Services.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateServiceStatus(int id, int status)
        {
            var service = _context.Services.Find(id);
            if (service != null)
            {
                service.Status = status;
                _context.SaveChanges();
            }
        }
    }
}
