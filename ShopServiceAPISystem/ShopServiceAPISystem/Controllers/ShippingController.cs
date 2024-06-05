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
            var shippings = await _shippingService.GetAllShippings();
            if (shippings == null)
            {
                return NotFound();
            }
            return Ok(shippings);
        }

        [HttpGet]
        [Route("GetShippingById/{id}")]
        public async Task<IActionResult> GetShippingById(int id)
        {
            var shipping = await _shippingService.GetShippingById(id);
            if (shipping == null)
            {
                return NotFound();
            }
            return Ok(shipping);
        }

        [HttpPost]
        [Route("CreateShipping")]
        public async Task<IActionResult> CreateShipping([FromBody] RequestShippingDTO shippingDTO)
        {
            var shippingId = await _shippingService.CreateShipping(shippingDTO);
            if (shippingId == 0)
            {
                return StatusCode(500, "Error creating shipping");
            }

            var createdShipping = await _shippingService.GetShippingById(shippingId);
            if (createdShipping == null)
            {
                return StatusCode(500, "Error fetching newly created shipping");
            }

            return CreatedAtAction(nameof(GetShippingById), new { id = createdShipping.Id }, createdShipping);
        }

        [HttpPut]
        [Route("UpdateShipping/{id}")]
        public async Task<IActionResult> UpdateShipping(int id, [FromBody] RequestShippingDTO shippingDTO)
        {

            var shippingId = await _shippingService.UpdateShipping(id, shippingDTO);
            if (shippingId == 0)
            {
                return StatusCode(500, "Error updating shipping");
            }

            var updatedShipping = await _shippingService.GetShippingById(id);

            return Ok(updatedShipping);
        }

        [HttpDelete]
        [Route("DeleteShipping/{id}")]
        public async Task<IActionResult> DeleteShipping(int id)
        {
            var message = await _shippingService.DeleteShipping(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPut]
        [Route("UpdateShippingStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateShippingStatus(int id, int status)
        {
            var shipping = await _shippingService.UpdateShippingStatus(id, status);
            if (shipping == null)
            {
                return NotFound();
            }
            return Ok(shipping);
        }
    }
}
