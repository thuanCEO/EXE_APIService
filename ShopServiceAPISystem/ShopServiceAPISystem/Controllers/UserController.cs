using AutoMapper;
using BusinessObjects.Models;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ShopServiceAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        private readonly IMapper _mapper;
        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string userName, string password)
        {
            User user = _userService.Login(userName, password);
            if (user == null)
            {
                return NotFound("Invalid username or password");
            }

            return Ok(_userService.GenerateToken(user));
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult Create([FromBody] UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            _userService.CreateUser(user);
            return Created("",1);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return Ok("deleted");
        }

    }
}
