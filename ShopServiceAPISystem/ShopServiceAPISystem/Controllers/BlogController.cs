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
    public class BlogController : ControllerBase
    {
        private BlogService _blogService;
        private readonly IMapper _mapper;
        public BlogController(BlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllBlogs")]
        public IActionResult GetAllBlogs()
        {
            return Ok(_blogService.GetAllBlogs());
        }
        [HttpGet]
        [Route("GetBlogByID")]
        public IActionResult GetBlogByID(int id)
        {
            return Ok(_blogService.GetBlogByID(id));
        }
        [HttpPost]
        [Route("CreateBlog")]
        public IActionResult Create([FromBody] BlogDTO blogDTO)
        {
            Blog blog = _mapper.Map<Blog>(blogDTO);
            _blogService.AddBlog(blog);
            return Created("", 1);
        }
    }
}
