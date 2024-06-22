﻿using AutoMapper;
using BusinessObjects.Models;
using DTOs.Create;
using DTOs.Update;
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

        [HttpGet]
        [Route("GetUserById")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string userName, string password)
        {
            User user = _userService.Login(userName, password);
            if (user == null)
            {
                return NotFound("Sai tên đăng nhập hoặc mật khẩu");
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult Create([FromBody] CreateUserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            _userService.CreateUser(user);
            return Created("", "Đã tạo account");
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateUserDTO userDTO, int id)
        {
            var user = _mapper.Map<User>(userDTO);
            user.Id = id;
            await _userService.UpdateUser(user, userDTO.Image);
            return Ok("Update thành công");
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return Ok("Đã xóa");
        }
        [HttpPost]
        [Route("LoginGoogle")]
        public async Task<IActionResult> LoginGoogle(string idToken)
        {
            User user = await _userService.LoginGoogle(idToken);
            return Ok(user);
        }
    }
}
