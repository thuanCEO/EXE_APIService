using BusinessObjects.Models;
using Firebase.Storage;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessObjects
{
    public class UserDAO
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context = new bs6ow0djyzdo8teyhoz4Context();
        private readonly IConfiguration _configuration;
        public UserDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void CreateUser(User user)
        {
            bool usernameExists = _context.Users.Any(u => u.UserName == user.UserName);
            if (usernameExists)
            {
                throw new Exception("Username bị trùng");
            }
            user.Status = 1;
            user.RoleId = 3;
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task UpdateUser(User user, IFormFile image)
        {
            User existingUser = _context.Users.FirstOrDefault(p => p.Id == user.Id);
            if (image != null)
            {
                var imageUrl = await UploadImageToFirebase(image, existingUser.FullName);
                user.Avatar = imageUrl;
            }
            else
            {
                user.Avatar = existingUser.Avatar;
            }
            _context.Entry(existingUser).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return false;
            if (user != null)
            {
                user.Status = 0;
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            return true;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users
                .OrderByDescending(x => x.Id)
                .Include(x => x.Orders)
                .ThenInclude(x => x.OrderDetails)
                .Include(x => x.Blogs)
                .Include(x => x.Carts)
                .ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users
                .Include(x => x.Orders)
                .ThenInclude(x => x.OrderDetails)
                .Include(x => x.Blogs)
                .Include(x => x.Carts)
                .FirstOrDefault(x => x.Id == id);
        }

        public User Login(string userName, string password)
        {

            return _context.Users.FirstOrDefault(x => x.UserName.Equals(userName) && x.Password.Equals(password));
        }

        public string GenerateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration["AppSettings:SecretKey"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserName", user.UserName),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Role", user.RoleId.ToString()),
                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }
        private async Task<string> UploadImageToFirebase(IFormFile image, string name)
        {

            var stream = image.OpenReadStream();
            var task = new FirebaseStorage(
                _configuration["Firebase:Bucket"],
                new FirebaseStorageOptions
                {
                    ThrowOnCancel = true
                })
                .Child("images")
                .Child(DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + name)
                .PutAsync(stream);

            return await task;
        }

        public async Task<User> LoginGoogle(string idToken)
        {
            try
            {
                // Xác thực idToken và lấy thông tin người dùng từ Google
                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);

                // Tìm người dùng trong cơ sở dữ liệu dựa trên email
                var user = _context.Users.FirstOrDefault(u => u.Email == payload.Email);
                if (user == null)
                {
                    // Tạo người dùng mới nếu không tồn tại
                    user = new User
                    {
                        FullName = payload.Name,
                        Email = payload.Email,
                        Avatar = payload.Picture,
                        UserName = payload.Email, // Sử dụng email làm tên người dùng
                        Status = 1,
                        RoleId = 3
                    };
                    _context.Users.Add(user);
                }
                else
                {
                    // Cập nhật người dùng hiện tại
                    user.FullName = payload.Name;
                    user.Avatar = payload.Picture;
                    _context.Users.Update(user);
                }

                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu idToken không hợp lệ
                throw new Exception("Invalid Google token", ex);
            }
        }
    }
}
