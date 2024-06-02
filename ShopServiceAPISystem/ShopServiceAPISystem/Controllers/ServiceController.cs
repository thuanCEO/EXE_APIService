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
            var response = await _serviceService.GetAllServices();
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetServiceById/{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var response = await _serviceService.GetServiceById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateService")]
        public async Task<IActionResult> CreateService([FromBody] RequestServiceDTO serviceDTO)
        {
            var response = await _serviceService.CreateService(serviceDTO);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return CreatedAtAction(nameof(GetServiceById), new { id = response.Data }, response);
        }

        [HttpPut]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] RequestServiceDTO serviceDTO)
        {
            var response = await _serviceService.UpdateService(id, serviceDTO);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteService/{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var response = await _serviceService.DeleteService(id);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateServiceStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateServiceStatus(int id, int status)
        {
            var response = await _serviceService.UpdateServiceStatus(id, status);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }
    }
}