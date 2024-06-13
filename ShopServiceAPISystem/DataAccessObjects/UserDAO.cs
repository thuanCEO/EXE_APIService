using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DataAccessObjects
{
    public class UserDAO
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context;
        private readonly IConfiguration _configuration;
        public UserDAO(bs6ow0djyzdo8teyhoz4Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void CreateUser(User user)
        {
            user.Status = 1;
            user.RoleId = 3;
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            User existingUser = _context.Users.FirstOrDefault(p => p.Id == user.Id);
            _context.Entry(existingUser).CurrentValues.SetValues(user);
            _context.SaveChanges();
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
    }
}
