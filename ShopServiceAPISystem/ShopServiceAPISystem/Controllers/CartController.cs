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
            var carts = await _cartService.GetAllCarts();
            if (carts == null)
            {
                return NotFound();
            }
            return Ok(carts);
        }

        [HttpGet]
        [Route("GetCartById/{id}")]
        public async Task<IActionResult> GetCartById(int id)
        {
            var cart = await _cartService.GetCartById(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost]
        [Route("CreateCart")]
        public async Task<IActionResult> CreateCart([FromBody] RequestCartDTO cartDTO)
        {
            var cartId = await _cartService.CreateCart(cartDTO);
            if (cartId == 0)
            {
                return StatusCode(500, "Error creating cart");
            }

            var createdCart = await _cartService.GetCartById(cartId);
            if (createdCart == null)
            {
                return StatusCode(500, "Error fetching newly created cart");
            }

            return CreatedAtAction(nameof(GetCartById), new { id = createdCart.Id }, createdCart);
        }

        [HttpPut]
        [Route("UpdateCart/{id}")]
        public async Task<IActionResult> UpdateCart(int id, [FromBody] RequestCartDTO cartDTO)
        {
            var cartId = await _cartService.UpdateCart(id, cartDTO);
            if (cartId == 0)
            {
                return StatusCode(500, "Error updating cart");
            }

            var updatedCart = await _cartService.GetCartById(id);

            return Ok(updatedCart);
        }

        [HttpDelete]
        [Route("DeleteCart/{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var message = await _cartService.DeleteCart(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPut]
        [Route("UpdateCartStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateCartStatus(int id, int status)
        {
            var cart = await _cartService.UpdateCartStatus(id, status);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }
    }
}
