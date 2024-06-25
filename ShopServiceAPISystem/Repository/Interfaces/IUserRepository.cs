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
        Task<User> LoginGoogle(string idToken);
        int CountUsers(int? status = null);
        Task<bool> ForgotPassword(string email);
        Task SendEmailAsync(string toEmail, string subject, string message, List<IFormFile> attachments = null);
        void UpdatePassword(int userId, string Password);
    }
}
