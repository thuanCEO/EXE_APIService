using AutoMapper;
using DTOs.Services;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopServiceAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceService _serviceService;

        public ServiceController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        [Route("GetAllServices")]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _serviceService.GetAllServices();
            if (services == null || services.Count == 0)
            {
                return NotFound("No services found.");
            }
            return Ok(services);
        }

        [HttpGet]
        [Route("GetServiceById/{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _serviceService.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [HttpPost]
        [Route("CreateService")]
        public async Task<IActionResult> CreateService([FromBody] RequestServiceDTO serviceDTO)
        {
            var serviceId = await _serviceService.CreateService(serviceDTO);
            if (serviceId == 0)
            {
                return StatusCode(500, "Error creating service");
            }

            var createdService = await _serviceService.GetServiceById(serviceId);
            if (createdService == null)
            {
                return StatusCode(500, "Error fetching newly created service");
            }

            return CreatedAtAction(nameof(GetServiceById), new { id = createdService.Id }, createdService);
        }

        [HttpPut]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] RequestServiceDTO serviceDTO)
        {
            var serviceId = await _serviceService.UpdateService(id, serviceDTO);
            if (serviceId == 0)
            {
                return StatusCode(500, "Error updating service");
            }

            var updatedService = await _serviceService.GetServiceById(id);

            return Ok(updatedService);
        }

        [HttpDelete]
        [Route("DeleteService/{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var message = await _serviceService.DeleteService(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPut]
        [Route("UpdateServiceStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateServiceStatus(int id, int status)
        {
            var service = await _serviceService.UpdateServiceStatus(id, status);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }
    }
}
