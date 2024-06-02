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
            var response = await _cartProductService.GetAllCartProducts();
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetCartProductById/{id}")]
        public async Task<IActionResult> GetCartProductById(int id)
        {
            var response = await _cartProductService.GetCartProductById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateCartProduct")]
        public async Task<IActionResult> CreateCartProduct([FromBody] RequestCartProductDTO cartProductDTO)
        {
            var response = await _cartProductService.CreateCartProduct(cartProductDTO);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return CreatedAtAction(nameof(GetCartProductById), new { id = response.Data }, response);
        }

        [HttpPut]
        [Route("UpdateCartProduct/{id}")]
        public async Task<IActionResult> UpdateCartProduct(int id, [FromBody] RequestCartProductDTO cartProductDTO)
        {
            var response = await _cartProductService.UpdateCartProduct(id, cartProductDTO);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteCartProduct/{id}")]
        public async Task<IActionResult> DeleteCartProduct(int id)
        {
            var response = await _cartProductService.DeleteCartProduct(id);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateCartProductStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateCartProductStatus(int id, int status)
        {
            var response = await _cartProductService.UpdateCartProductStatus(id, status);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }
    }
}
