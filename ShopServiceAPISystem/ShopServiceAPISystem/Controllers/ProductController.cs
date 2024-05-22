using AutoMapper;
using BusinessObjects.Models;
using DTOs;
using Microsoft.AspNetCore.Http;
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
        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult Create([FromBody] ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            _productService.CreateProduct(product);
            return Created("", 1);
        }
    }
}
