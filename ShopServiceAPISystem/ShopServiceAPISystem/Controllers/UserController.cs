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
        public UserController(UserService userService)
        {
            _userService = userService;
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
            _userService.CreateUser(userDTO);
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
