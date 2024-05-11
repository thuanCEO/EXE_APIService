using BusinessObjects;
using DataAccessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopServiceAPISystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserBLL _BLL;
        public UserController(UserBLL BLL)
        {
            _BLL = BLL;
        }

        [HttpGet]
        [Route("getAllUsers")]
        public List<User> GetAllUsers()
        {
            return _BLL.GetAllUsers();
        }

        [HttpGet]
        [Route("getUserByUserNameAndPassword")]
        public IActionResult GetUserByUserNameAndPassword(string userName, string password)
        {
            User user = _BLL.GetUserByUserNameAndPassword(userName, password);
            if (user == null)
            {
                return NotFound("Invalid username or password");
            }
            return Ok(user);
        }

    }
}
