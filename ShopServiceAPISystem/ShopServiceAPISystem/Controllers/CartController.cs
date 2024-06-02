using AutoMapper;
using DTOs.Carts;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopServiceAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        [Route("GetAllCarts")]
        public async Task<IActionResult> GetAllCarts()
        {
            var response = await _cartService.GetAllCarts();
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetCartById/{id}")]
        public async Task<IActionResult> GetCartById(int id)
        {
            var response = await _cartService.GetCartById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateCart")]
        public async Task<IActionResult> CreateCart([FromBody] RequestCartDTO cartDTO)
        {

            var response = await _cartService.CreateCart(cartDTO);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return CreatedAtAction(nameof(GetCartById), new { id = response.Data }, response);
        }

        [HttpPut]
        [Route("UpdateCart/{id}")]
        public async Task<IActionResult> UpdateCart(int id, [FromBody] RequestCartDTO cartDTO)
        {
            var response = await _cartService.UpdateCart(id, cartDTO);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteCart/{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var response = await _cartService.DeleteCart(id);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateCartStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateCartStatus(int id, int status)
        {
            var response = await _cartService.UpdateCartStatus(id, status);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }
    }
}
