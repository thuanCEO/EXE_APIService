using AutoMapper;
using DTOs.Cartproducts;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopServiceAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartProductController : ControllerBase
    {
        private readonly CartProductService _cartProductService;

        public CartProductController(CartProductService cartProductService)
        {
            _cartProductService = cartProductService;
        }

        [HttpGet]
        [Route("GetAllCartProducts")]
        public async Task<IActionResult> GetAllCartProducts()
        {
            var cartProducts = await _cartProductService.GetAllCartProducts();
            if (cartProducts == null || cartProducts.Count == 0)
            {
                return NotFound("No cart products found");
            }
            return Ok(cartProducts);
        }

        [HttpGet]
        [Route("GetCartProductById/{id}")]
        public async Task<IActionResult> GetCartProductById(int id)
        {
            var cartProduct = await _cartProductService.GetCartProductById(id);
            if (cartProduct == null)
            {
                return NotFound("Cart product not found");
            }
            return Ok(cartProduct);
        }

        [HttpPost]
        [Route("CreateCartProduct")]
        public async Task<IActionResult> CreateCartProduct([FromBody] RequestCartProductDTO cartProductDTO)
        {
            var cartProductId = await _cartProductService.CreateCartProduct(cartProductDTO);
            if (cartProductId == 0)
            {
                return StatusCode(500, "Error creating cart product");
            }

            var createdCartProduct = await _cartProductService.GetCartProductById(cartProductId);
            if (createdCartProduct == null)
            {
                return StatusCode(500, "Error fetching newly created cart product");
            }

            return CreatedAtAction(nameof(GetCartProductById), new { id = createdCartProduct.Id }, createdCartProduct);
        }

        [HttpPut]
        [Route("UpdateCartProduct/{id}")]
        public async Task<IActionResult> UpdateCartProduct(int id, [FromBody] RequestCartProductDTO cartProductDTO)
        {
            var cartProductId = await _cartProductService.UpdateCartProduct(id, cartProductDTO);
            if (cartProductId == 0)
            {
                return StatusCode(500, "Error updating cart product");
            }

            var updatedCartProduct = await _cartProductService.GetCartProductById(id);

            return Ok(updatedCartProduct);
        }

        [HttpDelete]
        [Route("DeleteCartProduct/{id}")]
        public async Task<IActionResult> DeleteCartProduct(int id)
        {
            var success = await _cartProductService.DeleteCartProduct(id);
            if (!success)
            {
                return NotFound("Cart product not found");
            }
            return Ok("Cart product deleted successfully.");
        }

        [HttpPut]
        [Route("UpdateCartProductStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateCartProductStatus(int id, int status)
        {
            var cartProduct = await _cartProductService.UpdateCartProductStatus(id, status);
            if (cartProduct == null)
            {
                return NotFound("Cart product not found");
            }
            return Ok(cartProduct);
        }
    }
}
