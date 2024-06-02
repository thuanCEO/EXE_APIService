using AutoMapper;
using DTOs.shippings;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopServiceAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly ShippingService _shippingService;

        public ShippingController(ShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        [HttpGet]
        [Route("GetAllShippings")]
        public async Task<IActionResult> GetAllShippings()
        {
            var response = await _shippingService.GetAllShippings();
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetShippingById/{id}")]
        public async Task<IActionResult> GetShippingById(int id)
        {
            var response = await _shippingService.GetShippingById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateShipping")]
        public async Task<IActionResult> CreateShipping([FromBody] RequestShippingDTO shippingDTO)
        {
            var response = await _shippingService.CreateShipping(shippingDTO);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateShipping/{id}")]
        public async Task<IActionResult> UpdateShipping(int id, [FromBody] RequestShippingDTO shippingDTO)
        {
            var response = await _shippingService.UpdateShipping(id, shippingDTO);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteShipping/{id}")]
        public async Task<IActionResult> DeleteShipping(int id)
        {
            var response = await _shippingService.DeleteShipping(id);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateShippingStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateShippingStatus(int id, int status)
        {
            var response = await _shippingService.UpdateShippingStatus(id, status);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }
    }
}
