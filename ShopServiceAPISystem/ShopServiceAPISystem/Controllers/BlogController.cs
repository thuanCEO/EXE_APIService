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
        [Route("GetBlogById")]
        public IActionResult GetBlogById(int id)
        {
            return Ok(_blogService.GetBlogById(id));
        }

        [HttpPost]
        [Route("CreateBlog")]
        public IActionResult CreateBlog([FromBody] CreateBlogDTO blogDTO)
        {
            Blog blog = _mapper.Map<Blog>(blogDTO);
            _blogService.CreateBlog(blog);
            return Created("", "Tạo thành công");
        }

        [HttpPut]
        [Route("UpdateBlog")]
        public IActionResult UpdateBlog([FromBody] UpdateBlogDTO blogDTO, int id)
        {
            var blog = _mapper.Map<Blog>(blogDTO);
            blog.Id = id;
            _blogService.UpdateBlog(blog);
            return Ok("Update thành công");
        }

        [HttpDelete]
        [Route("DeleteBlog")]
        public IActionResult DeleteBlog(int id)
        {
            if (_blogService.DeleteBlog(id) == true)
            {
                return Ok("Xóa thành công");
            }
            else
                return StatusCode(500, "Không tồn tại Id này");

        }
    }
}
