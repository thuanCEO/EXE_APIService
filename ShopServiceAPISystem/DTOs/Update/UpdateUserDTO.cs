﻿using Microsoft.AspNetCore.Http;

namespace DTOs.Update
{
    public class UpdateUserDTO
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public IFormFile? Image { get; set; }
        public int? Status { get; set; }
        public int? RoleId { get; set; }
    }
}
