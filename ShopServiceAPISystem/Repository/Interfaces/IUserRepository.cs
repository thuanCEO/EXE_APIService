using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User Login(string userName, string password);
        void CreateUser(User user);
        Task UpdateUser(User user, IFormFile image);
        void DeleteUser(int id);
        string GenerateToken(User user);
    }
}
