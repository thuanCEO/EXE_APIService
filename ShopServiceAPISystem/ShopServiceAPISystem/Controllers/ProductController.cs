using AutoMapper;
using BusinessObjects.Models;
using DTOs.Create;
using DTOs.Update;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ShopServiceAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(ProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet]
        [Route("GetProductById")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_productService.GetProductById(id));
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            await _productService.CreateProduct(product, productDTO.Image);
            return Created("", "Tạo thành công");
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] UpdateProductDTO productDTO, int id)
        {
            var product = _mapper.Map<Product>(productDTO);
            product.Id = id;
            _productService.UpdateProduct(product);
            return Ok("Update thành công");
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            if (_productService.DeleteProduct(id) == true)
            {
                return Ok("Xóa thành công");
            }
            else
                return StatusCode(500, "Không tồn tại Id này");

        }
    }
}
